using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApiData.Models
{
    public class TestStep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool ErrorFlag { get; set; }
        public int TestCaseId { get; set; }
        [JsonIgnore]
        public TestCase TestCase { get; set; }

    }
}
