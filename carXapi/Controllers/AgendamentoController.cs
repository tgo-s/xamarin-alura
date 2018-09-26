using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carXapi.model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace carXapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : Controller
    {
        [HttpPost("marcar")]
        public void Marcar([FromBody] string value)
        {
            Agendamento agendamento = JsonConvert.DeserializeObject<Agendamento>(value);
        }
    }
}