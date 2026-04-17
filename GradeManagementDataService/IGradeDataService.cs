using System.Collections.Generic;
using Nayan_Grade_Management.GradeManagementModels;

namespace Nayan_Grade_Management.GradeManagementDataService
{
    public interface IGradeDataService
    {
        List<Student> GetAllStudents();
        bool StudentExists(int id);
        Student GetStudentById(int id);
        void SaveStudent(Student updatedStudent);
        void UpdateStudent(Student updatedStudent);
        void DeleteStudentGrades(int id);
    }
}
