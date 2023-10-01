using System;
using Coraza_LabActivity1.Models;
namespace Coraza_LabActivity1.Services
{
    public interface IMyFakeDataService
    {
        List<Instructor> InstructorList { get; }

        List<Student> StudentList { get; }
    }
}
