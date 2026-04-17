using System.Collections.Generic;
using Nayan_Grade_Management.GradeManagementDataService;
using Nayan_Grade_Management.GradeManagementModels;

namespace Nayan_Grade_Management.GradeManagementAppService
{
    public class GradeAppService
    {
        GradeDataService gradeDataService = new GradeDataService(new GradeDBData());
        //GradeDataService gradeDataService = new GradeDataService(new GradeInMemoryData());
        //GradeDataService gradeDataService = new GradeDataService(new GradeJsonData());

        public List<Student> GetAllStudents()
        {
            return gradeDataService.GetAllStudents();
        }

        public bool StudentExists(int id)
        {
            return gradeDataService.StudentExists(id);
        }

        public Student GetStudentById(int id)
        {
            return gradeDataService.GetStudentById(id);
        }

        public void SaveStudent(Student updatedStudent)
        {
            gradeDataService.SaveStudent(updatedStudent);
        }

        public void UpdateStudent(Student updatedStudent)
        {
            gradeDataService.UpdateStudent(updatedStudent);
        }

        public void DeleteStudentGrades(int id)
        {
            gradeDataService.DeleteStudentGrades(id);
        }

        public bool IsValidMenuChoice(int choice)
        {
            return choice >= 0 && choice <= 5;
        }

        public bool IsValidStudentId(int studentId, int studentCount)
        {
            return studentId >= 0 && studentId < studentCount;
        }

        public bool IsValidGradeFieldChoice(int choice)
        {
            return choice >= 1 && choice <= 5;
        }

        public bool IsValidScore(double score, double maxScore)
        {
            return score >= 0 && score <= maxScore;
        }

        public double ConvertScoreToPercentage(double score, double maxScore)
        {
            return (score / maxScore) * 100;
        }

        public double CalculateTotalScore(Grades grades)
        {
            double quizPart = grades.QuizOne * 0.20;
            double attendancePart = grades.Attendance * 0.10;
            double midtermsPart = grades.Midterms * 0.25;
            double finalsPart = grades.Finals * 0.25;
            double projectPart = grades.Project * 0.20;

            return quizPart + attendancePart + midtermsPart + finalsPart + projectPart;
        }

        public void SaveStudentGrades(Student student, Grades grades)
        {
            grades.TotalScore = CalculateTotalScore(grades);
            student.Grades = grades;
            SaveStudent(student);
        }

        public void UpdateStudentGrade(Student student, int gradeFieldChoice, double score)
        {
            switch (gradeFieldChoice)
            {
                case 1:
                    student.Grades.QuizOne = score;
                    break;

                case 2:
                    student.Grades.Attendance = score;
                    break;

                case 3:
                    student.Grades.Midterms = score;
                    break;

                case 4:
                    student.Grades.Finals = score;
                    break;

                case 5:
                    student.Grades.Project = score;
                    break;
            }

            student.Grades.TotalScore = CalculateTotalScore(student.Grades);
            UpdateStudent(student);
        }
    }
}
