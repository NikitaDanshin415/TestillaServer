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
    public class TestCaseRepository : IRepository<TestCase>
    {
        private readonly WebApiCoreContext context;

        public TestCaseRepository(WebApiCoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<TestCase> GetAll()
        {
            List<TestCase> testCases = context.TestCases.ToList();

            foreach(var testCase in testCases)
            {
                context.TestCases.Include(x => x.Steps).ToList();
             }
            
            return context.TestCases.ToList();
        }


        public int Add(TestCase entity)
        {
            context.TestCases.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }

        public void Delete(TestCase entity)
        {
            context.TestCases.Remove(entity);
            context.SaveChanges();
        }

        public TestCase FindById(int id)
        {
            var testCase = context.TestCases.FirstOrDefault(x => x.Id.Equals(id));
            
            if(testCase == null)
            {
                return null;
            }

            context.TestCases.Include(x => x.Steps).ToList();
            return testCase;
        }

        public void Update(TestCase entity)
        {
            context.TestCases.Update(entity);
            context.SaveChanges();
        }
    }
}
