using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class UserClientController : Controller
    {
        IHostingEnvironment _IHostingEnvironment;
        IHttpContextAccessor _IHttpContextAccessor;
        IUnitOfWork<myDBContext> _uow;
        IWorkshopService _IWorkshopService;
        ISectionService _ISectionService;
        IContentService _IContentService;
        IUserClientService _IUserClientService;
        IResponseDataService _IResponseDataService;
        IDocumentsService _IDocumentsService;
        IUserService _IUserService;

        public UserClientController(
            IHostingEnvironment _IHostingEnvironment,
            IHttpContextAccessor _IHttpContextAccessor,
            IUnitOfWork<myDBContext> _uow,
            IWorkshopService _IWorkshopService,
            ISectionService _ISectionService,
           IContentService _IContentService,
            IUserClientService _IUserClientService,
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
            this._IUserClientService = _IUserClientService;
            this._IResponseDataService = _IResponseDataService;
            this._IDocumentsService = _IDocumentsService;
            this._IUserService = _IUserService;
        }


        [HttpPost]
        public IActionResult GetPaging(DTParameters<UserClient> param, UserClient searchModel)
        {
            var result = _IUserClientService.GetPaging(null, true, param, false, o => o.UserClientSession);
            return Json(result);
        }
        public IActionResult GetAll()
        {
            var result = _IUserClientService.Where(null, true, false, o => o.UserClientSession);
            return Json(result);
        }

        public RModel<UserClient> Get(int id)
        {
            var result = _IUserClientService.Where(o => o.Id == id, true, false, o => o.UserClientSession);
            return (result);
        }
        public IActionResult Delete(int id)
        {
            var deleteRow = _IUserClientService.Delete(id);
            var delete = _uow.SaveChanges();
            return Json(delete);
        }
        public IActionResult InsertOrUpdate(UserClient postModel)
        {
            var result = _IUserClientService.InsertOrUpdate(postModel);
            if (result.RType == RType.OK)
            {
                var save = _uow.SaveChanges();
                return Json(save);
            }
            return Json(result);
        }
        public IActionResult Index()
        {
            ViewBag.pageTitle = "UserClient";
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
