using ClassLibrary2;
using ClassLibrary2.Repository;
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
    public class TestStepController : ControllerBase
    {

        public IRepository<TestStep> context { get; private set; }
        public TestStepController(IRepository<TestStep> context)
        {
            this.context = context;
        }


        // GET: api/<TestStepsController>
        [HttpGet]
        public ActionResult<IEnumerable<TestStep>> Get()
        {
            var testStepList = context.GetAll();

            if (testStepList == null)
            {
                return NotFound(testStepList);
            }

            return Ok(testStepList);
        }

        // GET api/<TestStepsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestStepsController>
        [HttpPost]
        public ActionResult Post([FromBody] TestStep value)
        {
            value.CreateDate = DateTime.Now.Date;
            value.UpdateDate = DateTime.Now.Date;
            int id = context.Add(value);

            return Ok(id);
        }

        // POST api/<TestStepsController>
        [HttpPost("array")]
        public ActionResult Post([FromBody] TestStep[] value)
        {

            foreach(var el in value)
            {
                el.CreateDate = DateTime.Now.Date;
                el.UpdateDate = DateTime.Now.Date;
                context.Add(el);
            }

            return Ok();
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
