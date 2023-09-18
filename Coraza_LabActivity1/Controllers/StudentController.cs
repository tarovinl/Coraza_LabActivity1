using Coraza_LabActivity1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coraza_LabActivity1.Controllers
{
    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>
        {
            new Student()
            {
                Id = 1,
                Name = "Edvin Ryding",
                Course = Course.BSIT,
                DateEnrolled = DateTime.Parse ("04/09/2023 20:04:30")
            },
            new Student()
            {
                Id = 2,
                Name = "Kit Connor",
                Course = Course.BSCS,
                DateEnrolled = DateTime.Parse ("22/04/2022 04:08:04")
            },
            new Student()
            {
                Id = 3,
               Name = "Kim Kibum",
                Course = Course.BSIS,
                DateEnrolled = DateTime.Parse ("23/09/2020 20:08:30")
            }


        };

        public object StudentsList { get; private set; }

        public IActionResult Index()
        {
            return View(StudentList);
        }
        public IActionResult ShowDetail(int id)
        {
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);
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
            StudentList.Add(newStudent);

            return View("Index", StudentList);
        
        }

        public IActionResult Edit(int id)
        {
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

                return student != null ? View(student) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Student studentChange)
        {
            Student? student = StudentList.FirstOrDefault(st => st.Id == studentChange.Id);
                if (student != null)
            {
                student.Id = studentChange.Id;
                student.Name = studentChange.Name;
                student.Course = studentChange.Course;
                student.DateEnrolled = studentChange.DateEnrolled;
            }
                return View("Index", StudentList);
        }

    }
    

}
