using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ToDoAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public Guid Id { get; set; }


        public TestController(IConfiguration config, IScoped scoped, IScoped scoped1, ITransiant trans, ITransiant trans1, ISingleTon ston) {
            //var tc = new DefaultHttpContext().RequestServices.GetRequiredService<ITest>();
            Id = scoped.Id;
            string val = config["TestKey"];
        }

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var tc = this.HttpContext.RequestServices.GetRequiredService<ITest>();
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        //[ProducesResponseType(typeof(string), 200)]
        //[ProducesResponseType(typeof(int), 204)]
        //public Results<NoContent, Ok<int>> Get(int id)
        public ActionResult<int> Get(int id)
        {
            if (id == 1)
                return NotFound(id);
            return Ok(id);
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public interface ITest { }
    public class TestClass : ITest
    {
        IScoped iscopedObj = null;
        
        public TestClass(IScoped scoped, ITransiant trans, ISingleTon ston) {
            iscopedObj = scoped;
        }
    }
}
