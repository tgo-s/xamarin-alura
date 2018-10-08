using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carXapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("/auth")]
        public string Login()
        {
            return "Sucesso";
        }

        //[HttpGet("/auth")]
        //public string Login()
        //{
        //    return "Sucesso";
        //}
    }
}