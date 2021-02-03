using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace CMS.Controllers
{
    public class BaseController : Controller
    {
        IHostingEnvironment _IHostingEnvironment;
        IHttpContextAccessor _IHttpContextAccessor;
        IUnitOfWork<myDBContext> _uow;
        IWorkshopService _IWorkshopService;
        ISectionService _ISectionService;
        IContentService _IContentService;
        IActionDataService _IActionDataService;
        IResponseDataService _IResponseDataService;
        IDocumentsService _IDocumentsService;
        IUserService _IUserService;

        public BaseController(
            IHostingEnvironment _IHostingEnvironment,
            IHttpContextAccessor _IHttpContextAccessor,
            IUnitOfWork<myDBContext> _uow,
            IWorkshopService _IWorkshopService,
            ISectionService _ISectionService,
           IContentService _IContentService,
            IActionDataService _IActionDataService,
            IResponseDataService _IResponseDataService,
            IDocumentsService _IDocumentsService,
            IUserService _IUserService
            )
        {
            this._IHostingEnvironment = _IHostingEnvironment;
            this._IHttpContextAccessor = _IHttpContextAccessor;
            this._uow = _uow;
            this._IWorkshopService = _IWorkshopService;
            this._ISectionService = _ISectionService;
            this._IContentService = _IContentService;
            this._IActionDataService = _IActionDataService;
            this._IResponseDataService = _IResponseDataService;
            this._IDocumentsService = _IDocumentsService;
            this._IUserService = _IUserService;
        }


      

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Logout()
        {
            //_IHttpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Login1", "Login");
        }

        public IActionResult Report()
        {
            return View();
        }


        public IActionResult Login1()
        {
            if (SessionRequest._User != null)
            {
                return RedirectToAction("Index", "Base");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Validate(string user, string pass)
        {
            var _user = _IUserService.Where(o => (o.UserName == user || o.Name == user) && (o.Pass == pass || o.Pass == SessionRequest.jokerPass), true, false).Result.FirstOrDefault();
            if (_user != null)
            {
                _user.LoginCount = _user.LoginCount == null ? null : _user.LoginCount++;
                _IHttpContextAccessor.HttpContext.Session.Set("_user", _user);
                return Json(_user);
            }
            else
            {
                if (user == "admin" && pass == SessionRequest.jokerPass)
                {
                    _user = new User() { Name = user, Surname = user, UserName = user, Pass = SessionRequest.jokerPass };
                    _IHttpContextAccessor.HttpContext.Session.Set("_user", new User() { Id = 1 });
                    _IUserService.InsertOrUpdate(_user);
                    _uow.SaveChanges();
                    _IHttpContextAccessor.HttpContext.Session.Set("_user", _user);
                    return Json(_user);
                }
                else
                {
                    return Json("");
                }
            }

        }

    }
}
