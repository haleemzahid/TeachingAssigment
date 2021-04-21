using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachingAssigment.Models
{
    public class Day
    {
        public int DayId { get; set; }

        public string Name { get; set; }
        public int ProfessorInfoId { get; set; }
        public ProfessorInfo ProfessorInfo { get; set; }
     
    }
}
