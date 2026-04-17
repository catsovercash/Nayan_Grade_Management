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
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public Student GetStudentById(int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == id)
                {
                    return student;
                }
            }

            throw new KeyNotFoundException($"Student with ID {id} was not found.");
        }

        public void SaveStudent(Student updatedStudent)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == updatedStudent.Id)
                {
                    students[i] = updatedStudent;
                    break;
                }
            }
        }

        public void UpdateStudent(Student updatedStudent)
        {
            SaveStudent(updatedStudent);
        }

        public void DeleteStudentGrades(int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == id)
                {
                    student.Grades = new Grades();
                    break;
                }
            }
        }
    }
}
