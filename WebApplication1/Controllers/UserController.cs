using ClassLibrary2;
using ClassLibrary2.Models;
using ClassLibrary2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    [Authorize]
    public class UserController : ControllerBase
    {
        public IRepository<User> context { get; private set; }

        public UserController(IRepository<User> context)
        {
            this.context = context;
        }


        // GET: api/<UserController>
        [HttpGet]
        public string Get()
        {
            var users = context.GetAll();
            return System.Text.Json.JsonSerializer.Serialize(users);
        }

        // GET: api/<UserController>
        [HttpGet("getUserInfo")]
        public string GetTest()
        {
            var claims = User.Claims.ToList();

            int id = int.Parse(claims[0].Value);
            

            var user = context.FindById(id);
            return JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);

        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            
            var user = context.FindById(id);
            return JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            context.Update(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            context.Add(value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = context.FindById(id);
            context.Delete(entity);
            Ok();
        }
    }
}
