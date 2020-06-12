using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Common
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Operation { get; set; }
    }
    public class StudentRequestDto
    {
        public int value { get; set; }
    }
}
