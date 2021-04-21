using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SapnaTeachingAssignment.LinkList;
using SapnaTeachingAssignment.Models;

namespace SapnaTeachingAssignment.Controllers
{
    public class ProfessorInfoesController : Controller
    {
        
        public List<Day> Days { get; set; } = new List<Day>();
        public List<Time> Time { get; set; } = new List<Time>();
        public ProfessorInfoesController()
        {
           

            Days.Add(new Day { Name = "S" });
            Days.Add(new Day { Name = "M" });
            Days.Add(new Day { Name = "T" });
            Days.Add(new Day { Name = "W" });
            Days.Add(new Day { Name = "T" });
            Days.Add(new Day { Name = "F" });


            Time.Add(new Time { Name = "8" });
            Time.Add(new Time { Name = "9" });
            Time.Add(new Time { Name = "10" });
            Time.Add(new Time { Name = "11" });
            Time.Add(new Time { Name = "12" });
            Time.Add(new Time { Name = "1" });
            Time.Add(new Time { Name = "2" });
            Time.Add(new Time { Name = "3" });
            Time.Add(new Time { Name = "4" });
            Time.Add(new Time { Name = "5" });
            Time.Add(new Time { Name = "6" });
        }

        // GET: ProfessorInfoes
        public async Task<IActionResult> Index()
        {


            var data = LinkList.ProfList.data.ToList();



            ViewBag.Days = Days;
            ViewBag.Time = Time;


            return View(data);
        }

        // GET: ProfessorInfoes/Details/5
       

        // GET: ProfessorInfoes/Create
    

        // POST: ProfessorInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorInfoId,Name,CourseCode,CourseDay,CourseTime,LectureName")] ProfessorInfo professorInfo)
        {

            if (!ValidationProfessor(professorInfo)) 
            {

                return View("You can not Assign to this professor");
                
            }
            else
            {
                ProfList.data.AddLast(professorInfo);
            }
            return View(professorInfo);
        }

        public bool ValidationProfessor(ProfessorInfo professorInfo)
        {

            var data = LinkList.ProfList.data.ToList().Where(x=>x.ProfessorInfoId==professorInfo.ProfessorInfoId).ToList();

            if (data.Count > 4)
            {
                return false;
            }
            else if (data.Any(x=>x.CourseDay==professorInfo.CourseDay))
            {
                return false;
            }
            else if (data.Any(x => x.CourseTime == professorInfo.CourseTime))
            {

                return false;
            }





            return true;
        }




        // GET: ProfessorInfoes/Edit/5
       
    }
}
