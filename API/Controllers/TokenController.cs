using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _IUserService;
        private readonly AppSettings _AppSettings;

        public TokenController(
            IOptions<AppSettings> _AppSettings,
            IUserService _IUserService
            )
        {
            this._IUserService = _IUserService;
            this._AppSettings = _AppSettings.Value;
        }

        //Burada da AllowAnonymous attribute nü kullanarak bu seferde bu metoda herkesin erişebilecek.
        [AllowAnonymous]
        [HttpGet("Authenticate")]
        public IActionResult Authenticate(string username, string password)
        {
            if (username == _AppSettings.Username && password == _AppSettings.Password)
            {
                _AppSettings.Username = username;
                _AppSettings.Password = password;

                // Token oluşturmak için önce JwtSecurityTokenHandler sınıfından instance alıyorum.
                var tokenHandler = new JwtSecurityTokenHandler();
                //İmza için gerekli gizli anahtarımı alıyorum.
                var key = Encoding.ASCII.GetBytes(_AppSettings.SecretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //Özel olarak şu Claimler olsun dersek buraya ekleyebiliriz.
                    Subject = new ClaimsIdentity(new[]
                    {
                    //İstersek string bir property istersek ClaimsTypes sınıfının sabitlerinden çağırabiliriz.
                    new Claim("guid", Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name,_AppSettings.Username)
                }),
                    //Tokenın hangi tarihe kadar geçerli olacağını ayarlıyoruz.
                    Expires = DateTime.UtcNow.AddDays(1),
                    //Son olarak imza için gerekli algoritma ve gizli anahtar bilgisini belirliyoruz.
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                };

                //Token oluşturuyoruz.
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //Oluşturduğumuz tokenı string olarak bir değişkene atıyoruz.
                string generatedToken = tokenHandler.WriteToken(token);


                _AppSettings.Token = generatedToken;
            }
            else
            {
                _AppSettings.Username = username;
                _AppSettings.Password = password;
                _AppSettings.SecretKey = "";
            }


            return Ok(_AppSettings);
        }

    }
}
