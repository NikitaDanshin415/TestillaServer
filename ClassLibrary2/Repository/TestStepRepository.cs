using ClassLibrary2;
using ClassLibrary2.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiData.Models;

namespace WebApiData.Repository
{
    public class TestStepRepository : IRepository<TestStep>
    {
        private readonly WebApiCoreContext context;

        public TestStepRepository(WebApiCoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<TestStep> GetAll()
        {
            List<TestStep> testSteps = context.TestSteps.ToList();

            foreach (var testStep in testSteps)
            {
                context.TestCases.Include(x => x.Steps).ToList();

            }

            return context.TestSteps.ToList();
        }

        public int Add(TestStep entity)
        {
            context.TestSteps.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }

        public void Delete(TestStep entity)
        {
            throw new NotImplementedException();
        }

        public TestStep FindById(int id)
        {
            throw new NotImplementedException();
        }
                
        public void Update(TestStep entity)
        {
            context.TestSteps.Update(entity);
            context.SaveChanges();
        }
    }
}
