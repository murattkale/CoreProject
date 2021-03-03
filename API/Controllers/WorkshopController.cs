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
    public class WorkshopController : ControllerBase
    {
        IWorkshopService _IWorkshopService;
        public WorkshopController(IWorkshopService _IWorkshopService)
        {
            this._IWorkshopService = _IWorkshopService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _IWorkshopService.Where(null, true, false);
            return Ok(result);
        }




    }
}
