using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Components
{

    public class DynamicInput : ViewComponent
    {

        IHttpContextAccessor _httpContextAccessor;
        IDocumentsService _IDocumentsService;

        public DynamicInput(
            IDocumentsService _IDocumentsService,
        IHttpContextAccessor httpContextAccessor
            )
        {
            this._httpContextAccessor = httpContextAccessor;
            this._IDocumentsService = _IDocumentsService;
        }


        public IViewComponentResult Invoke(DynamicModel postModel)
        {
            if (postModel.PageType == "Documents")
            {
                return View("DynamicInput_Documents", postModel);
            }
            else
            {
                return View("DynamicInput", postModel);
            }


        }


       

    }
}