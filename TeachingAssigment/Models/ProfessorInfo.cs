using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapnaTeachingAssignment.Models
{
    public class ProfessorInfo
    {
        public int ProfessorInfoId { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string CourseDay { get; set; }
        public string CourseTime { get; set; }
        public string LectureName { get; set; }
        public ICollection<Day> Days { get; set; }
        public ICollection<Time> Times { get; set; }


    }
}
