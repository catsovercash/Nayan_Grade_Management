using System.Collections.Generic;
using Nayan_Grade_Management.GradeManagementModels;

namespace Nayan_Grade_Management.GradeManagementDataService
{
    public class GradeInMemoryData : IGradeDataService
    {
        public List<Student> students;

        public GradeInMemoryData()
        {
            students = new List<Student>
            {
                new Student { Id = 0, Name = "John Carlo Nayan"},
                new Student { Id = 1, Name = "Lebron James" },
                new Student { Id = 2, Name = "Paul George" },
                new Student { Id = 3, Name = "Boss Atan" },
                new Student { Id = 4, Name = "Beabadobee" }
            };
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public bool StudentExists(int id)
        {
            return id >= 0 && id < students.Count;
        }

        public Student GetStudentById(int id)
        {
            return students[id];
        }

        public void SaveStudent(Student updatedStudent)
        {
            int studentIndex = students.FindIndex(student => student.Id == updatedStudent.Id);

            if (studentIndex >= 0)
            {
                students[studentIndex] = updatedStudent;
            }
        }
    }
}
