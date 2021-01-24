using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CMS.Controllers
{
    public class WorkshopController : Controller
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

        public WorkshopController(
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



        [HttpPost]
        public IActionResult GetPaging(DTParameters<Workshop> param, Workshop searchModel)
        {
            var result = _IWorkshopService.GetPaging(null, true, param, false);
            return Json(result);
        }
        public IActionResult GetAll()
        {
            var result = _IWorkshopService.Where();
            return Json(result);
        }

        public IActionResult getCategoryType()
        {
            var list = Enum.GetValues(typeof(CategoryType)).Cast<int>().Select(x => new { name = ((CategoryType)x).ToStr(), value = x.ToString(), text = ((CategoryType)x).ExGetDescription() }).ToArray();
            return Json(list);
        }
        public IActionResult GetSelect()
        {
            var result = _IWorkshopService.Where().Result.Select(o => new TextValue { value = o.Id, text = o.Name }).ToArray();
            return Json(result);
        }

        public RModel<Workshop> Get(int id)
        {
            var result = _IWorkshopService.Where(o => o.Id == id);
            return (result);
        }


        public IActionResult Delete(int id)
        {
            _IWorkshopService.Delete(id);
            var delete = _uow.SaveChanges();
            return Json(delete);
        }

        public IActionResult InsertOrUpdate(Workshop postModel)
        {
            var result = _IWorkshopService.InsertOrUpdate(postModel);
            if (result.RType == RType.OK)
            {
                var save = _uow.SaveChanges();
                return Json(save);
            }
            return Json(result);
        }


        public IActionResult Index()
        {
            ViewBag.pageTitle = "Workshop";
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
