using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region BaseServices

            //add controller with views support
            var mvcBuilder = services.AddControllersWithViews();

            ////add newtonsoft json serializer
            mvcBuilder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });


            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new DefaultContractResolver()
            };


            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();//To Store session in Memory, This is default implementation of IDistributedCache    
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(60));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddEntityFrameworkSqlServer().AddDbContext<myDBContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("myDBContext"), b => b.MigrationsAssembly("myDBContext")));

            services.AddScoped(typeof(IBaseSession), typeof(BaseSession));
            services.AddScoped(typeof(IGenericRepo<IBaseModel>), typeof(GenericRepo<myDBContext, IBaseModel>));
            services.AddScoped(typeof(IUnitOfWork<myDBContext>), typeof(UnitOfWork<myDBContext>));
            #endregion


            var allprops = AppDomain.CurrentDomain.GetAssemblies();
            var props = allprops.Where(o => o.ManifestModule.Name == "Services.dll").FirstOrDefault().DefinedTypes;
            var servicesAll = props.Where(o => (!o.IsInterface && o.BaseType.Name.Contains("GenericRepo"))).ToList();
            servicesAll.ForEach(baseService =>
            {
                services.AddScoped(baseService.GetInterface("I" + baseService.Name), baseService);
            });


            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Oluþturduðumuz gizli anahtarýmýzý byte dizisi olarak alýyoruz.
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            IdentityModelEventSource.ShowPII = true;

            //Projede farklý authentication tipleri olabileceði için varsayýlan olarak JWT ile kontrol edeceðimizin bilgisini kaydediyoruz.
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                //JWT kullanacaðým ve ayarlarý da þunlar olsun dediðimiz yer ise burasýdýr.
                .AddJwtBearer(x =>
                {
                    //Gelen isteklerin sadece HTTPS yani SSL sertifikasý olanlarý kabul etmesi(varsayýlan true)
                    x.RequireHttpsMetadata = false;
                    //Eðer token onaylanmýþ ise sunucu tarafýnda kayýt edilir.
                    x.SaveToken = true;
                    //Token içinde neleri kontrol edeceðimizin ayarlarý.
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Token 3.kýsým(imza) kontrolü
                        ValidateIssuerSigningKey = true,
                        //Neyle kontrol etmesi gerektigi
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        //Bu iki ayar ise "aud" ve "iss" claimlerini kontrol edelim mi diye soruyor
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WIP API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //CORS için hangi ayarlarý kullanacaðýmýzý belirtiyoruz.
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseSwagger();
            //app.UseHsts();
            //app.UseHttpsRedirection();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WIP API");
            });


            //Son olarak authentication kullanacaðýmýzý belirtiyoruz.
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorMid>();
            app.UseStaticFiles();

            SessionRequest.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            var supportedCultures = new[] { new CultureInfo("en-EN") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-EN"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
    }
}
