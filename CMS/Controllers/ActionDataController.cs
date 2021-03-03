using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class ActionDataController : Controller
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

        public ActionDataController(
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


        public IActionResult getActionType()
        {
            var list = Enum.GetValues(typeof(ActionType)).Cast<int>().Select(x => new { name = ((ActionType)x).ToStr(), value = x.ToString(), text = ((ActionType)x).ExGetDescription() }).ToArray();
            return Json(list);
        }



        [HttpPost]
        public IActionResult GetPaging(DTParameters<object> param, int ContentId)
        {
            var rd = _IResponseDataService.Where(o => o.ContentId == ContentId, true, false, o => o.Content).Result.ToList();
            var ad = _IActionDataService.Where(null, true, false, o => o.Content).Result.ToList();

            var query = rd.Select(o => new
            {
                Id = o.Id,
                ReponseContent = o.ReponseContent,
                Content =
                ad
                .FirstOrDefault(oo => oo.ResponseDataId == o.Id)?.Content,
                ActionDataId = ad
                .FirstOrDefault(oo => oo.ResponseDataId == o.Id)?.Id

            }).AsQueryable();

            var GlobalSearchFilteredData = query.ToGlobalSearchInAllColumn<object>(param);
            var IndividualColSearchFilteredData = GlobalSearchFilteredData.ToIndividualColumnSearch(param);
            var SortedFilteredData = IndividualColSearchFilteredData.ToSorting(param);
            var SortedData = SortedFilteredData.ToPagination(param);

            var rSortedData = SortedData.ToList();

            int Count = query.Count();

            var resultData = new DTResult<object>
            {
                draw = param.Draw,
                data = rSortedData,
                recordsFiltered = Count,
                recordsTotal = Count
            };

            return Json(resultData);
        }
        public IActionResult GetAll()
        {
            var result = _IActionDataService.Where(null, true, false, o => o.Content);
            return Json(result);
        }

        public RModel<ActionData> Get(int id)
        {
            var result = _IActionDataService.Where(o => o.Id == id, true, false, o => o.Content);
            return (result);
        }
        public IActionResult Delete(int id)
        {
            var deleteRow = _IActionDataService.Delete(id);
            var delete = _uow.SaveChanges();
            return Json(delete);
        }
        public IActionResult InsertOrUpdate(ActionData postModel)
        {
            var result = _IActionDataService.InsertOrUpdate(postModel);
            if (result.RType == RType.OK)
            {
                var save = _uow.SaveChanges();
                return Json(save);
            }
            return Json(result);
        }
        public IActionResult Index()
        {
            ViewBag.pageTitle = "ActionData";
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
