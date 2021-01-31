using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class ContentController : Controller
    {
        IHostingEnvironment _IHostingEnvironment;
        IHttpContextAccessor _IHttpContextAccessor;
        IUnitOfWork<myDBContext> _uow;
        IContentService _IContentService;
        IContentService _IWorkshopService;
        IActionDataService _IActionDataService;
        IResponseDataService _IResponseDataService;
        IDocumentsService _IDocumentsService;
        IUserService _IUserService;

        public ContentController(
            IHostingEnvironment _IHostingEnvironment,
            IHttpContextAccessor _IHttpContextAccessor,
            IUnitOfWork<myDBContext> _uow,
            IContentService _IContentService,
            IContentService _IWorkshopService,
            IActionDataService _IActionDataService,
            IResponseDataService _IResponseDataService,
            IDocumentsService _IDocumentsService,
            IUserService _IUserService
            )
        {
            this._IHostingEnvironment = _IHostingEnvironment;
            this._IHttpContextAccessor = _IHttpContextAccessor;
            this._uow = _uow;
            this._IContentService = _IContentService;
            this._IWorkshopService = _IWorkshopService;
            this._IActionDataService = _IActionDataService;
            this._IResponseDataService = _IResponseDataService;
            this._IDocumentsService = _IDocumentsService;
            this._IUserService = _IUserService;
        }


        [HttpPost]
        public IActionResult GetPaging(DTParameters<Content> param, Content searchModel)
        {
            var result = _IContentService.GetPaging(null, true, param, false, o => o.Section);
            return Json(result);
        }
        public IActionResult GetAll()
        {
            var result = _IContentService.Where(null, true, false, o => o.Section);
            return Json(result);
        }

        public RModel<Content> Get(int id)
        {
            var result = _IContentService.Where(o => o.Id == id, true, false, o => o.Section);
            return (result);
        }
        public IActionResult Delete(int id)
        {
            var deleteRow = _IContentService.Delete(id);
            var delete = _uow.SaveChanges();
            return Json(delete);
        }
        public IActionResult InsertOrUpdate(Content postModel)
        {
            var result = _IContentService.InsertOrUpdate(postModel);
            if (result.RType == RType.OK)
            {
                var save = _uow.SaveChanges();
                return Json(save);
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult SaveMultiDoc(List<Documents> DocList)
        {
            List<RModel<Documents>> rList = new List<RModel<Documents>>();
            DocList.ForEach(o =>
            {
                var result = _IDocumentsService.InsertOrUpdate(o);
                rList.Add(result);
            });
            return Json(rList);


        }
        public ActionResult GetDocuments(DTParameters<Documents> param, Documents searchModel)
        {
            var result = _IDocumentsService.GetPaging(o => o.ContentId == searchModel.ContentId, true, param, false);
            return Json(result);
        }


        public IActionResult Index()
        {
            ViewBag.pageTitle = "Content";
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
