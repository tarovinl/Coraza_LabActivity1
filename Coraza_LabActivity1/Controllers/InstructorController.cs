using Coraza_LabActivity1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Coraza_LabActivity1.Services;
using Coraza_LabActivity1.Data;

namespace Coraza_LabActivity1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public InstructorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Instructors);
        }
        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                return View(instructor);
            }

            return View();
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor) 
        {
            _dbContext.Instructors.Add(newInstructor);
            _dbContext.SaveChanges();
            return RedirectToAction("IndexInstructor");
        
        }

        public IActionResult Edit(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(inst => inst.Id == id);

                return instructor != null ? View(instructor) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructorChange)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(inst => inst.Id == instructorChange.Id);
                if (instructor != null)
            {
                instructor.Id = instructorChange.Id;
                instructor.FirstName = instructorChange.FirstName;
                instructor.LastName = instructorChange.LastName;
                instructor.IsTenured = instructorChange.IsTenured;
                instructor.Rank = instructorChange.Rank;
                instructor.HiringDate = instructorChange.HiringDate;
                _dbContext.SaveChanges();
            }
                return RedirectToAction("IndexInstructor");
        }
        [HttpGet]
        public IActionResult Delete(Instructor instructorDelete)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(it => it.Id == instructorDelete.Id);
            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(it => it.Id == id);
            if (instructor != null)
            {
                _dbContext.Instructors.Remove(instructor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();


        }

    }
    

}
