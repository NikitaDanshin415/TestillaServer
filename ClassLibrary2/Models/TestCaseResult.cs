using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApiData.Models
{
    class TestCaseResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public DateTime CreateDate { get; set; }

        public int AuthorId { get; set; }
        [JsonIgnore]
        public User Author { get; set; }

        public List<TestStepResult> Steps { get; set; }
    }
}
