using Nayan_Grade_Management.Services;

namespace Nayan_Grade_Management.UI
{
    internal static class ConsoleUI
    {
        public static int ReadMainMenuChoice()
        {
            while (true)
            {
                Console.Write("0. Exit\n1. Show All Student\n2. Set Student Grade\n3. Show Student Grade\nChoice: ");
                string? choice = Console.ReadLine();

                bool isValidChoice = int.TryParse(choice, out int userChoice) && userChoice >= 0 && userChoice <= 3;

                if (!isValidChoice)
                {
                    Console.Write("Invalid\n\n");
                    continue;
                }

                return userChoice;
            }
        }

        public static int ReadStudentId(int studentCount)
        {
            while (true)
            {
                Console.Write("Student ID Number: ");
                string? studentIdNumber = Console.ReadLine();

                bool isValidId = int.TryParse(studentIdNumber, out int userStudentIdNumber) &&
                                 userStudentIdNumber >= 0 &&
                                 userStudentIdNumber < studentCount;

                if (!isValidId)
                {
                    Console.WriteLine("Invalid ID Number");
                    continue;
                }

                return userStudentIdNumber;
            }
        }

        public static double ReadScore(string label, double maxScore)
        {
            while (true)
            {
                Console.Write($"{label} Score (?/{maxScore}): ");
                string? input = Console.ReadLine();

                bool isValidScore = double.TryParse(input, out double score) && score >= 0 && score <= maxScore;

                if (!isValidScore)
                {
                    Console.Write($"\n====================\n{label} Score must be 0 - {maxScore}\n====================\n\n");
                    continue;
                }

                return score;
            }
        }

        public static void ShowAllStudentNames(string[] studentNames)
        {
            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.WriteLine("ID " + i + ". " + studentNames[i]);
            }
        }

        public static void SetStudentGrade(string[] studentNames, double[,] studentGrades, int studentId)
        {
            Console.WriteLine(studentNames[studentId] + "'s Quiz One");
            double quizOneScore = ReadScore("Quiz 1", 20);

            Console.WriteLine(studentNames[studentId] + "'s Attendance");
            double attendanceScore = ReadScore("Attendance", 24);

            Console.WriteLine(studentNames[studentId] + "'s Midterms");
            double midtermsScore = ReadScore("Midterms", 100);

            Console.WriteLine(studentNames[studentId] + "'s Finals");
            double finalsScore = ReadScore("Finals", 100);

            Console.WriteLine(studentNames[studentId] + "'s Project");
            double projectScore = ReadScore("Project", 100);

            GradeService.SetStudentGrades(
                studentGrades,
                studentId,
                quizOneScore,
                attendanceScore,
                midtermsScore,
                finalsScore,
                projectScore
            );
        }

        public static void ShowStudentGrade(string[] studentNames, double[,] studentGrades, int studentId)
        {
            Console.WriteLine("Student Name: " + studentNames[studentId]);
            Console.WriteLine("Quiz One: " + studentGrades[studentId, 0] + "%");
            Console.WriteLine("Attendance: " + studentGrades[studentId, 1] + "%");
            Console.WriteLine("Midterms: " + studentGrades[studentId, 2] + "%");
            Console.WriteLine("Finals: " + studentGrades[studentId, 3] + "%");
            Console.WriteLine("Project: " + studentGrades[studentId, 4] + "%");
            Console.WriteLine("Total Score: " + studentGrades[studentId, 5] + "%");
            Console.WriteLine();
        }

        public static void ShowExitMessage()
        {
            Console.Write("Exiting...\n");
        }
    }
}
