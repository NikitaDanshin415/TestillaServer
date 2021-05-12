using ClassLibrary2;
using ClassLibrary2.Repository;
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
        public IRepository<TestCase> context { get; private set; }

        public TestCaseController(IRepository<TestCase> context)
        {
            this.context = context;
        }


        // GET: api/<TestCaseController>
        [HttpGet]
        public ActionResult<IEnumerable<TestCase>> Get()
        {
            var testCaseList = context.GetAll();

            if(testCaseList == null)
            {
                return NotFound(testCaseList);
            }

            return Ok(testCaseList);
        }

        // GET api/<TestCaseController>/5
        [HttpGet("{id}")]
        public ActionResult<TestCase> Get(int id)
        {
            TestCase testCase = context.FindById(id);

            if(testCase == null)
            {
                return NotFound();
            }

            return Ok(testCase);
        }

        // POST api/<TestCaseController>
        [HttpPost]
        public ActionResult Post([FromBody] TestCase value)
        {
            value.CreateDate = DateTime.Now.Date;
            value.UpdateDate = DateTime.Now.Date;
            int id = context.Add(value);


            var res = new { id };

            return Ok(res);
        }

        // PUT api/<TestCaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TestCase value)
        {
            context.Update(value);
            Ok();
        }

        // DELETE api/<TestCaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = context.FindById(id);
            context.Delete(entity);
            Ok();
        }
    }
}
