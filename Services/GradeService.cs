namespace Nayan_Grade_Management.Services
{
    internal static class GradeService
    {
        public static double CalculatePercentage(double score, double totalPossibleScore)
        {
            return (score / totalPossibleScore) * 100;
        }

        public static double CalculateTotal(double quizOne, double attendance, double midterms, double finals, double project)
        {
            return (quizOne * 0.20) + (attendance * 0.10) + (midterms * 0.25) + (finals * 0.25) + (project * 0.20);
        }

        public static void SetStudentGrades(double[,] studentGrades, int studentId, double quizOneScore, double attendanceScore, double midtermsScore, double finalsScore, double projectScore)
        {
            studentGrades[studentId, 0] = CalculatePercentage(quizOneScore, 20);
            studentGrades[studentId, 1] = CalculatePercentage(attendanceScore, 24);
            studentGrades[studentId, 2] = CalculatePercentage(midtermsScore, 100);
            studentGrades[studentId, 3] = CalculatePercentage(finalsScore, 100);
            studentGrades[studentId, 4] = CalculatePercentage(projectScore, 100);

            studentGrades[studentId, 5] = CalculateTotal(
                studentGrades[studentId, 0],
                studentGrades[studentId, 1],
                studentGrades[studentId, 2],
                studentGrades[studentId, 3],
                studentGrades[studentId, 4]
            );
        }
    }
}
