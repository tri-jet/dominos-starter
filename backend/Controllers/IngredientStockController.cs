using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // Returning dummy data to ensure the endpoint works
            // Will replace this with the SQL Server logic 
            var stock = new[] {
                new { Ingredient = "Pepperoni", Quantity = 50 },
                new { Ingredient = "Mozzarella", Quantity = 20 }
            };

            return Ok(stock);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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