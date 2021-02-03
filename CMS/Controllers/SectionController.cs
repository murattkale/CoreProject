using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class SectionController : Controller
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

        public SectionController(
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
        public IActionResult UpdateOrder(List<OrderUpdateModel> postModel)
        {
            var rows = _ISectionService.Where(o => o.WorkshopId == postModel.FirstOrDefault().dataid).Result.ToList();
            postModel.ForEach(o =>
            {
                var row = rows.FirstOrDefault(r => r.Id == o.Id);
                if (row != null)
                {
                    row.OrderNo = o.OrderNo;
                    _ISectionService.Update(row);
                }
            });
            _uow.SaveChanges();
            return Json("ok");
        }


        [HttpPost]
        public IActionResult GetPaging(DTParameters<Section> param, int selectid)
        {
            var result = _ISectionService.GetPaging(o => o.WorkshopId == selectid, true, param, false, o => o.Workshop);
            return Json(result);
        }

        [HttpPost]
        public IActionResult GetSelect()
        {
            var result = _ISectionService.Where(null, true, false, o => o.Workshop).Result.Select(o => new TextValue { text = o.Name + " " + (o.Workshop.Name), value = o.Id });
            return Json(result);
        }
        public RModel<Section> Get(int id)
        {
            var result = _ISectionService.Where(o => o.Id == id, true, false, o => o.Workshop);
            return (result);
        }
        public IActionResult Delete(int id)
        {
            var deleteRow = _ISectionService.Delete(id);
            var delete = _uow.SaveChanges();
            return Json(delete);
        }
        public IActionResult InsertOrUpdate(Section postModel)
        {
            var result = _ISectionService.InsertOrUpdate(postModel);
            if (result.RType == RType.OK)
            {
                var save = _uow.SaveChanges();
                return Json(save);
            }
            return Json(result);
        }
        public IActionResult Index()
        {
            ViewBag.pageTitle = "Section";
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
