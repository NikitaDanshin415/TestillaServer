using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiData.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestStepsController : ControllerBase
    {
        private readonly WebApiCoreContext context;

        public TestStepsController(WebApiCoreContext context)
        {
            this.context = context;
        }


        // GET: api/<TestStepsController>
        [HttpGet]
        public IEnumerable<TestStep> Get()
        {
            context.TestSteps.ToList();

            return context.TestSteps.ToList(); ;
        }

        // GET api/<TestStepsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestStepsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestStepsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestStepsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
