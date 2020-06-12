using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Common;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post(StudentRequestDto value)
        {
            var result = GenerateStudent(0, 50, value.value);
            return new JsonResult(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static List<Student> GenerateStudent(int minId, int maxId, int maxNumber)
        {
            var r = new Random();
            var students = new List<Student>();
            for (int i = 0; i < maxNumber; i++)
            {
                students.Add(new Student
                {
                    Id = r.Next(minId, maxId),
                    Name = $"name: {r.Next(1, 10)}",
                    Age = r.Next(6, 10)
                });
            }
            return students.GroupBy(s => s.Id).Select(s => s.First()).ToList();
        }
    }
}
