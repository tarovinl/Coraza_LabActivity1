using Coraza_LabActivity1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Coraza_LabActivity1.Services;

namespace Coraza_LabActivity1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public InstructorController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        public IActionResult Index()
        {
            return View(_fakeData.InstructorList);
        }
        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
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
            _fakeData.InstructorList.Add(newInstructor);

            return RedirectToAction("IndexInstructor");
        
        }

        public IActionResult Edit(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(inst => inst.Id == id);

                return instructor != null ? View(instructor) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructorChange)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(inst => inst.Id == instructorChange.Id);
                if (instructor != null)
            {
                instructor.Id = instructorChange.Id;
                instructor.FirstName = instructorChange.FirstName;
                instructor.LastName = instructorChange.LastName;
                instructor.IsTenured = instructorChange.IsTenured;
                instructor.Rank = instructorChange.Rank;
                instructor.HiringDate = instructorChange.HiringDate;
            }
                return RedirectToAction("IndexInstructor");
        }
        [HttpGet]
        public IActionResult Delete(Instructor instructorDelete)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(it => it.Id == instructorDelete.Id);
            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(it => it.Id == id);
            if (instructor != null)
            {
                _fakeData.InstructorList.Remove(instructor);
                return RedirectToAction("Index");
            }

            return NotFound();


        }

    }
    

}
