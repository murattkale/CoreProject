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
    public class ActionDataController : ControllerBase
    {
        IActionDataService _IActionDataService;
        public ActionDataController(IActionDataService _IActionDataService)
        {
            this._IActionDataService = _IActionDataService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _IActionDataService.Where(null, true, false);
            return Ok(result);
        }


        [HttpGet("GetActionData")]
        public IActionResult GetActionData(int ResponseDataId)
        {
            var result = _IActionDataService.Where(o => o.ResponseDataId == ResponseDataId, true, false, o => o.Content, o => o.ResponseData).Result
                .OrderBy(o => o.OrderNo).FirstOrDefault();
            return Ok(result);
        }




    }
}
