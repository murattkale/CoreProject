using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class UserClientSessionController : Controller
    {
        IHostingEnvironment _IHostingEnvironment;
        IHttpContextAccessor _IHttpContextAccessor;
        IUnitOfWork<myDBContext> _uow;
        IWorkshopService _IWorkshopService;
        ISectionService _ISectionService;
        IContentService _IContentService;
        IUserClientSessionService _IUserClientSessionService;
        IResponseDataService _IResponseDataService;
        IDocumentsService _IDocumentsService;
        IUserService _IUserService;

        public UserClientSessionController(
            IHostingEnvironment _IHostingEnvironment,
            IHttpContextAccessor _IHttpContextAccessor,
            IUnitOfWork<myDBContext> _uow,
            IWorkshopService _IWorkshopService,
            ISectionService _ISectionService,
           IContentService _IContentService,
            IUserClientSessionService _IUserClientSessionService,
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
            this._IUserClientSessionService = _IUserClientSessionService;
            this._IResponseDataService = _IResponseDataService;
            this._IDocumentsService = _IDocumentsService;
            this._IUserService = _IUserService;
        }


        [HttpPost]
        public IActionResult GetPaging(DTParameters<UserClientSession> param, UserClientSession searchModel)
        {
            var result = _IUserClientSessionService.GetPaging(null, true, param, false, o => o.UserClient, o => o.Section);
            return Json(result);
        }
        public IActionResult GetAll()
        {
            var result = _IUserClientSessionService.Where(null, true, false, o => o.UserClient, o => o.Section);
            return Json(result);
        }

        public RModel<UserClientSession> Get(int id)
        {
            var result = _IUserClientSessionService.Where(o => o.Id == id, true, false, o => o.UserClient, o => o.Section);
            return (result);
        }
        public IActionResult Delete(int id)
        {
            var deleteRow = _IUserClientSessionService.Delete(id);
            var delete = _uow.SaveChanges();
            return Json(delete);
        }
        public IActionResult InsertOrUpdate(UserClientSession postModel)
        {
            var result = _IUserClientSessionService.InsertOrUpdate(postModel);
            if (result.RType == RType.OK)
            {
                var save = _uow.SaveChanges();
                return Json(save);
            }
            return Json(result);
        }
        public IActionResult Index()
        {
            ViewBag.pageTitle = "UserClientSession";
            return View();
        }
        public IActionResult InsertOrUpdatePage()
        {
            var edit = Get(Request.Query["id"].ToInt());
            ViewBag.edit = edit?.Result?.FirstOrDefault();
            return View();
        }

    }
}
