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
    public class UserController : ControllerBase
    {
        IUserService _IUserService;
        public UserController(IUserService _IUserService)
        {
            this._IUserService = _IUserService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _IUserService.Where(null, true, false);
            return Ok(result);
        }




    }
}
