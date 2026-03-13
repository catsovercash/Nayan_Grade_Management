using Nayan_Grade_Management.GradeManagementModels;

namespace Nayan_Grade_Management.GradeManagementAppService
{
    public class GradeAppService
    {
        public bool IsValidMenuChoice(int choice)
        {
            return choice >= 0 && choice <= 3;
        }

        public bool IsValidStudentId(int studentId, int studentCount)
        {
            return studentId >= 0 && studentId < studentCount;
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
        }
    }
}
