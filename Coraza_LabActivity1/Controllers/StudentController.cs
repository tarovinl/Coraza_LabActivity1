using Coraza_LabActivity1.Data;
using Coraza_LabActivity1.Models;
using Coraza_LabActivity1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coraza_LabActivity1.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public StudentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_dbContext.Students);
        }
        public IActionResult ShowDetail(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View(student);
            }

            return View();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student newStudent) 
        {
            if (!ModelState.IsValid) //if the data is invalid
            {
                return View();//go back to the VIew
            }

            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return RedirectToAction("IndexStudent");
        
        }

        public IActionResult Edit(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

                return student != null ? View(student) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Student studentChange)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == studentChange.Id);
                if (student != null)
            {
                student.Id = studentChange.Id;
                student.Name = studentChange.Name;
                student.Course = studentChange.Course;
                student.DateEnrolled = studentChange.DateEnrolled;
                _dbContext.SaveChanges();
            }
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Student studentDelete)
        {
            Student? student = _dbContext.Students.FirstOrDefault(it => it.Id == studentDelete.Id);
            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(it => it.Id == id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();


        }

    }
    

}
