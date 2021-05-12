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

        public IEnumerable<User> GetAll()
        {
            var users = context.Users.ToList();

            foreach (var user in users)
            {
                context.Entry(user).Reference(x => x.Role).Load();
            }
            return users;
        }

        public int Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
            context.SaveChanges();
        }

        public User FindById(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id.Equals(id));
            if (user == null)
            {
                return null;
            }

            context.Entry(user).Reference(x => x.Role).Load();
            return user;
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
            context.SaveChanges();
        }
    }
}
