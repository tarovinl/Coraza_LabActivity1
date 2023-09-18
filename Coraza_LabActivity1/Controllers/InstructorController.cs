using Coraza_LabActivity1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coraza_LabActivity1.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1,
                FirstName = "Anton",
                LastName = "Lee",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateTime.Parse ("04/09/2023 18:00:00")
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "Kevin",
                LastName = "Coraza",
                Rank = Rank.AssistantProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateTime.Parse ("29/09/2022 2:19:29")
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Kirsten",
                LastName = "Dodgen",
                Rank = Rank.Instructor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateTime.Parse ("04/01/2023 10:50:34")
            },
            new Instructor()
            {
                Id = 4,
                FirstName = "Wonbin",
                LastName = "Park",
                Rank = Rank.AssociateProfessor,
                IsTenured = IsTenured.Probationary,
                HiringDate = DateTime.Parse ("29/09/2020 17:30:00")
            },
            new Instructor()
            {
                Id = 5,
                FirstName = "Nicholas",
                LastName = "Galitzine",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateTime.Parse ("22/07/2023 18:28:23")
            }


        };

        public object InstructorsList { get; private set; }

        public IActionResult Index()
        {
            return View(InstructorList);
        }
        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);
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
            InstructorList.Add(newInstructor);

            return View("Index", InstructorList);
        
        }

        public IActionResult Edit(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == id);

                return instructor != null ? View(instructor) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructorChange)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == instructorChange.Id);
                if (instructor != null)
            {
                instructor.Id = instructorChange.Id;
                instructor.FirstName = instructorChange.FirstName;
                instructor.LastName = instructorChange.LastName;
                instructor.IsTenured = instructorChange.IsTenured;
                instructor.Rank = instructorChange.Rank;
                instructor.HiringDate = instructorChange.HiringDate;
            }
                return View("Index", InstructorList);
        }

    }
    

}
