using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachingAssigment.Models
{
    public class ProfessorInfo
    {
        public int ProfessorInfoId { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string CourseDay { get; set; }
        public string CourseTime { get; set; }
        public string LectureName { get; set; }

        public int DayId { get; set; }
        public Day Day { get; set; }
        public int TimeId { get; set; }
        public Time Time { get; set; }

    }
}
