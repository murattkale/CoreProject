using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        IContentService _IContentService;
        public ContentController(IContentService _IContentService)
        {
            this._IContentService = _IContentService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int SectionId)
        {
            var result = _IContentService.Where(o => o.SectionId == SectionId, true, false, o => o.Section);
            return Ok(result);
        }


        [HttpGet("GetFirst")]
        public IActionResult GetFirst(int? ContentId, int? SectionId)
        {
            var result = _IContentService.Where(o => (ContentId > 0 ? o.Id == ContentId : o.SectionId == SectionId), true, false, o => o.ResponseData, o => o.Documents).Result
                .OrderBy(o => o.OrderNo).FirstOrDefault();
            return Ok(result);
        }




    }
}
