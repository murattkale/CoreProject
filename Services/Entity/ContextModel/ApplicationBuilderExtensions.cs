using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;


//dotnet ef migrations add db1 --context myDBContext --output-dir Migrations

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
    {
        using (IServiceScope scope = app.ApplicationServices.CreateScope())
        using (myDBContext context = scope.ServiceProvider.GetRequiredService<myDBContext>())
        {
            try
            {
                //apply migrations
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            //seed data
            SeedData(context);
        }

        return app;
    }

    private static void SeedData(myDBContext dataContext)
    {
       
    }
}
