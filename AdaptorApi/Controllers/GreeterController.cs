using AdaptorApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreeterController : ControllerBase
    {
        private readonly IGreeter greeter;

        public GreeterController(IGreeter greeter)
        {
            this.greeter = greeter;
        }
        // GET: api/<GreeterController>
        [HttpGet]
        public string Get()
        {
            return greeter.Greeting();
        }

        // GET api/<GreeterController>/
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GreeterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GreeterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GreeterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
