using carXapi.model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace carXapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        // GET api/values
        [HttpGet("get/lista-veiculos")]
        public ActionResult<IEnumerable<Veiculo>> GetListaVeiculos()
        {
            return new List<Veiculo>
            {
                new Veiculo{ Fabricante="Ford", Nome="Mustang", Preco=350000 },
                new Veiculo{ Fabricante="Ford", Nome="Maverick", Preco=150000 },
                new Veiculo{ Fabricante="GM", Nome="Camaro", Preco=340000 },
                new Veiculo{ Fabricante="GM", Nome="Corvette", Preco=35000 },
                new Veiculo{ Fabricante="Dodge", Nome="Charger", Preco=360000 },
                new Veiculo{ Fabricante="Dodge", Nome="Viper", Preco=500000 },

            };
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost("post")]
        public string Post([FromBody] string value)
        {
            return "Retorno Veiculo";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
