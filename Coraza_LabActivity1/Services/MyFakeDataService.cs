using System;
using Coraza_LabActivity1.Services;
using Coraza_LabActivity1.Models;
namespace Coraza_LabActivity1.Services
{
    public class MyFakeDataService : IMyFakeDataService
    {
        public List<Instructor> InstructorList { get; }

        public List<Student> StudentList { get; }
        //Constructor
        public MyFakeDataService()
        {
            InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Anton",
                    LastName = "Lee",
                    Rank = Rank.Professor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("04/09/2020 03:39:30 am")
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "Kevin",
                    LastName = "Coraza",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("29/09/2021 02:29:20 pm")
                },
                new Instructor()
                {
                    Id = 3,
                    FirstName = "Nicholas",
                    LastName = "Galitzine",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("29/09/2022 10:29:40 am")
                },
                new Instructor()
                {
                    Id = 4,
                    FirstName = "Kirsten",
                    LastName = "Dodgen",
                    Rank = Rank.AssociateProfessor,
                    IsTenured = IsTenured.Probationary,
                    HiringDate = DateTime.Parse("16/06/2023 12:09:30 pm")
                },

            };

            StudentList = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    Name = "Makoto Yuki",
                    Course = Course.BSIT,
                    DateEnrolled = DateTime.Parse("02/02/2024 09:12:03 am")
                },
                new Student()
                {
                    Id = 2,
                    Name = "Wonbin Park",
                    Course = Course.BSCS,
                    DateEnrolled = DateTime.Parse("02/03/2023 08:10:02 pm")
                },
                new Student()
                {
                    Id = 3,
                    Name = "Kit Connor",
                    Course = Course.BSIS,
                    DateEnrolled = DateTime.Parse("08/03/2022 01:04:06 pm")
                },
                new Student()
                {
                    Id = 4,
                    Name = "Mitsuru Kirijo",
                    Course = Course.BSIT,
                    DateEnrolled = DateTime.Parse("13/07/2021 01:02:03 am")
                },
                new Student()
                {
                    Id = 5,
                    Name = "Kim Kibum",
                    Course = Course.BSIS,
                    DateEnrolled = DateTime.Parse("23/09/2021 11:00:00 am")
                }
            };
        }
    }
}
