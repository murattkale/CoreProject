

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;


public static class SessionRequest
{
    private static IHttpContextAccessor _IHttpContextAccessor;

    public static void Configure(IHttpContextAccessor __IHttpContextAccessor)
    {
        _IHttpContextAccessor = __IHttpContextAccessor;
    }

    public static HttpContext _HttpContext => _IHttpContextAccessor.HttpContext;

    public static string Title = "WIP";
    public static string StartPage = "Base";
    public static string StartAction = "Login1";
    public static string version = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(".", "").Replace(" ", "");
    public static string copyright = $"{DateTime.Now.Year} © Yazılım&Tasarım (Software&Design)  <a target='_blank' href='#'> by Hybrid</a>";
    public static string layoutID = "4";
    public static string layoutUrlBase = $"";
    public static string layoutUrl = $"";
    public static string logo = "~/img/logo.svg";
    public static string defaultImage = "~/img/default.png";

    public static string jokerPass = "123_*1";



    public static User _User
    {
        get
        {
            return _IHttpContextAccessor.HttpContext.Session.Get<User>("_user");
                //?? new User() { Id = 1, CreaUser = 1, CreaDate = DateTime.Now, UserName = "admin", Name = "Admin", Surname = "Admin" };
        }
        set { }
    }

    public static string Trans(this string keyword)
    {
        return keyword;
    }
    //public static Kullanici _User { get; set; }

   


}


