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
            return students.Exists(student => student.Id == id);
        }

        public Student GetStudentById(int id)
        {
            Student? student = students.Find(existingStudent => existingStudent.Id == id);

            if (student is null)
            {
                throw new KeyNotFoundException($"Student with ID {id} was not found.");
            }

            return student;
        }

        public void SaveStudent(Student updatedStudent)
        {
            int studentIndex = students.FindIndex(student => student.Id == updatedStudent.Id);

            if (studentIndex >= 0)
            {
                students[studentIndex] = updatedStudent;
            }
        }

        public void UpdateStudent(Student updatedStudent)
        {
            SaveStudent(updatedStudent);
        }

        public void DeleteStudentGrades(int id)
        {
            Student? student = students.Find(existingStudent => existingStudent.Id == id);

            if (student is not null)
            {
                student.Grades = new Grades();
            }
        }
    }
}
