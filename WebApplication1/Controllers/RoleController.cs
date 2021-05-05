using ClassLibrary2;
using ClassLibrary2.Models;
using ClassLibrary2.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public IRepository<Role> context { get; private set; }
        public RoleController(IRepository<Role> contextRole)
        {
            this.context = contextRole;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public string Get()
        {
            var result = context.getAll();
            return JsonSerializer.Serialize(result);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var result = context.FindById(id);
            return JsonSerializer.Serialize(result);
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] Role value)
        {
            context.Update(value);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Role value)
        {
            context.Add(value);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = context.FindById(id);
            context.Delete(entity);
        }
    }
}
