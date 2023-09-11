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
                HiringDate = DateOnly.Parse ("04/09/2023")
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "Kevin",
                LastName = "Coraza",
                Rank = Rank.AssistantProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse ("29/09/2022")
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Kirsten",
                LastName = "Dodgen",
                Rank = Rank.Instructor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse ("04/01/2023")
            },
            new Instructor()
            {
                Id = 4,
                FirstName = "Wonbin",
                LastName = "Park",
                Rank = Rank.AssociateProfessor,
                IsTenured = IsTenured.Probationary,
                HiringDate = DateOnly.Parse ("29/09/2020")
            },
            new Instructor()
            {
                Id = 5,
                FirstName = "Nicholas",
                LastName = "Galitzine",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse ("22/07/2023")
            }


        };
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
    }
}
