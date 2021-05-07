using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class TestCaseController : ControllerBase
    {
        private readonly WebApiCoreContext context;

        public TestCaseController(WebApiCoreContext context)
        {
            this.context = context;
        }

        // GET: api/<TestCaseController>
        [HttpGet]
        public IEnumerable<TestCase> Get()
        {
            List<TestCase> testCases = context.TestCases.ToList();
            context.TestCases.Include(x => x.Steps).ToList();
            return context.TestCases.ToList();
        }

        // GET api/<TestCaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestCaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestCaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestCaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
