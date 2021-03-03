using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Service.Interfaces;

namespace QTSC_ORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello world!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserReturn>> Login(LoginInfo loginInfo)
        {
            try
            {
                UserReturn userReturn = await _authService.Login(loginInfo);
                return Ok(userReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserReturn>> Register(RegisterInfo registerInfo)
        {
            try
            {
                UserReturn userReturn = await _authService.Register(registerInfo);
                return Ok(userReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
