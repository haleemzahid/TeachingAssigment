using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeachingAssigment.Models;

namespace TeachingAssigment.Data
{
    public class TeachingAssigmentContext : DbContext
    {
        public TeachingAssigmentContext (DbContextOptions<TeachingAssigmentContext> options)
            : base(options)
        {
        }

        public DbSet<TeachingAssigment.Models.ProfessorInfo> ProfessorInfo { get; set; }
    }
}
