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
    public class SectionController : ControllerBase
    {
        ISectionService _ISectionService;
        public SectionController(ISectionService _ISectionService)
        {
            this._ISectionService = _ISectionService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int WorkshopId)
        {
            var result = _ISectionService.Where(o => o.WorkshopId == WorkshopId, true, false, o => o.Workshop, o => o.Content);
            return Ok(result);
        }




    }
}
