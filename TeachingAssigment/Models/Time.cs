using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapnaTeachingAssignment.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public string  Name { get; set; }
        public int ProfessorInfoId { get; set; }
        public ProfessorInfo ProfessorInfo { get; set; }
    }
}
