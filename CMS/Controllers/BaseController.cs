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
        //IHostingEnvironment _IHostingEnvironment;
        //IHttpContextAccessor _IHttpContextAccessor;
        //IUnitOfWork<myDBContext> _uow;
        //IWorkshopService _IWorkshopService;
        //ISectionService _ISectionService;
        //IContentService _IContentService;
        //IActionDataService _IActionDataService;
        //IResponseDataService _IResponseDataService;
        //IDocumentsService _IDocumentsService;
        //IUserService _IUserService;

        //public BaseController(
        //    IHostingEnvironment _IHostingEnvironment,
        //    IHttpContextAccessor _IHttpContextAccessor,
        //    IUnitOfWork<myDBContext> _uow,
        //    IWorkshopService _IWorkshopService,
        //    ISectionService _ISectionService,
        //   IContentService _IContentService,
        //    IActionDataService _IActionDataService,
        //    IResponseDataService _IResponseDataService,
        //    IDocumentsService _IDocumentsService,
        //    IUserService _IUserService
        //    )
        //{
        //    this._IHostingEnvironment = _IHostingEnvironment;
        //    this._IHttpContextAccessor = _IHttpContextAccessor;
        //    this._uow = _uow;
        //    this._IWorkshopService = _IWorkshopService;
        //    this._ISectionService = _ISectionService;
        //    this._IContentService = _IContentService;
        //    this._IActionDataService = _IActionDataService;
        //    this._IResponseDataService = _IResponseDataService;
        //    this._IDocumentsService = _IDocumentsService;
        //    this._IUserService = _IUserService;
        //}



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


    }
}
