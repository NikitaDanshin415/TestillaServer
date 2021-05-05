using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly WebApiCoreContext context;
        

        public RoleRepository(WebApiCoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Role> getAll()
        { 
            return context.Roles.ToList();
        }

        public void Add(Role entity)
        {
            context.Roles.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            context.Roles.Remove(entity);
            context.SaveChanges();
        }

        public Role FindById(int id)
        {
            return context.Roles.FirstOrDefault(x => x.id.Equals(id));
        }

        public void Update(Role entity)
        {
            context.Roles.Update(entity);
            context.SaveChanges();
        }
    }
}
