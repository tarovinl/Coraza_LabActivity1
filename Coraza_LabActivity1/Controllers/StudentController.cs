using Coraza_LabActivity1.Models;
using Coraza_LabActivity1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coraza_LabActivity1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public StudentController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }


        public IActionResult Index()
        {
            return View(_fakeData.StudentList);
        }
        public IActionResult ShowDetail(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
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
            _fakeData.StudentList.Add(newStudent);

            return RedirectToAction("IndexStudent");
        
        }

        public IActionResult Edit(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

                return student != null ? View(student) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Student studentChange)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == studentChange.Id);
                if (student != null)
            {
                student.Id = studentChange.Id;
                student.Name = studentChange.Name;
                student.Course = studentChange.Course;
                student.DateEnrolled = studentChange.DateEnrolled;
            }
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Student studentDelete)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(it => it.Id == studentDelete.Id);
            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(it => it.Id == id);
            if (student != null)
            {
                _fakeData.StudentList.Remove(student);
                return RedirectToAction("Index");
            }

            return NotFound();


        }

    }
    

}
