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
    public class ResponseDataController : ControllerBase
    {
        IResponseDataService _IResponseDataService;
        public ResponseDataController(IResponseDataService _IResponseDataService)
        {
            this._IResponseDataService = _IResponseDataService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int ContentId)
        {
            var result = _IResponseDataService.Where(o => o.ContentId == ContentId, true, false, o => o.Content);
            result.Result = result.Result.OrderBy(o => o.OrderNo).AsQueryable();
            return Ok(result);
        }




    }
}
