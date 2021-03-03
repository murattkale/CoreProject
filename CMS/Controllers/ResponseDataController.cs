using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class ResponseDataController : Controller
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

        public ResponseDataController(
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

        public IActionResult getResponseType()
        {
            var list = Enum.GetValues(typeof(ResponseType)).Cast<int>().Select(x => new { name = ((ResponseType)x).ToStr(), value = x.ToString(), text = ((ResponseType)x).ExGetDescription() }).ToArray();
            return Json(list);
        }



        
        public IActionResult GetAll()
        {
            var result = _IResponseDataService.Where(null, true, false, o => o.Content);
            return Json(result);
        }

        public RModel<ResponseData> Get(int id)
        {
            var result = _IResponseDataService.Where(o => o.Id == id, true, false, o => o.Content);
            return (result);
        }
        public IActionResult Delete(int id)
        {
            var deleteRow = _IResponseDataService.Delete(id);
            var delete = _uow.SaveChanges();
            return Json(delete);
        }
        public IActionResult InsertOrUpdate(ResponseData postModel)
        {
            var result = _IResponseDataService.InsertOrUpdate(postModel);
            var save = _uow.SaveChanges();
            if (save.RType == RType.OK)
                return Json(result);
            else
                return Json(save);
        }
        public IActionResult Index()
        {
            ViewBag.pageTitle = "ResponseData";
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
