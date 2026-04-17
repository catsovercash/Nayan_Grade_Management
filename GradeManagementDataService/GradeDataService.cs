using System.Collections.Generic;
using Nayan_Grade_Management.GradeManagementModels;

namespace Nayan_Grade_Management.GradeManagementDataService
{
    public class GradeDataService
    {
        private readonly IGradeDataService _gradeData;

        public GradeDataService(IGradeDataService gradeData)
        {
            _gradeData = gradeData;
        }

        public List<Student> GetAllStudents()
        {
            return _gradeData.GetAllStudents();
        }

        public bool StudentExists(int id)
        {
            return _gradeData.StudentExists(id);
        }

        public Student GetStudentById(int id)
        {
            return _gradeData.GetStudentById(id);
        }

        public void SaveStudent(Student updatedStudent)
        {
            _gradeData.SaveStudent(updatedStudent);
        }

        public void UpdateStudent(Student updatedStudent)
        {
            _gradeData.UpdateStudent(updatedStudent);
        }

        public void DeleteStudentGrades(int id)
        {
            _gradeData.DeleteStudentGrades(id);
        }
    }
}
