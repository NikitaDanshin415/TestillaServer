using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly WebApiCoreContext context;

        public UserRepository(WebApiCoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> getAll()
        {
            var users = context.Users.ToList();

            foreach (var user in users)
            {
                context.Entry(user).Reference(x => x.role).Load();
            }
            return users;
        }

        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
            context.SaveChanges();
        }

        public User FindById(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.id.Equals(id));
            if (user == null)
            {
                return null;
            }

            context.Entry(user).Reference(x => x.role).Load();
            return user;
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
            context.SaveChanges();
        }
    }
}
