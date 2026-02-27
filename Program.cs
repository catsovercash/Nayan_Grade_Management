using System;

namespace Nayan_Grade_Management
{
    internal class Program
    {
        static double quizOne()
        {
            string input;
            bool access;
            double percentage, score;

            while (true)
            {
                Console.Write("Quiz 1 Score (?/20): ");
                input = Console.ReadLine();

                access = double.TryParse(input, out score) && score >= 0 && score <= 20 ;

                if (!access)
                {
                    Console.Write("\n====================\nQuiz 1 Score must be 0 - 20\n====================\n\n");
                    continue;
                }
                else
                {
                    break;
                }

            }

            percentage = (score / 20) * 100;
            return percentage;
        }

        static double attendance()
        {
            string input;
            bool access;
            double percentage, score;

            while (true)
            {
                Console.Write("Attendance Score (?/24): ");
                input = Console.ReadLine();

                access = double.TryParse(input, out score) && score >= 0 && score <= 24;

                if (!access)
                {
                    Console.Write("\n====================\nAttendance Score must be 0 - 24\n====================\n\n");
                    continue;
                }
                else
                {
                    break;
                }

            }

            percentage = (score / 24) * 100;
            return percentage;
        }

        static double midterms()
        {
            string input;
            bool access;
            double percentage, score;

            while (true)
            {
                Console.Write("Midterms Score (?/100): ");
                input = Console.ReadLine();

                access = double.TryParse(input, out score) && score >= 0 && score <= 100;

                if (!access)
                {
                    Console.Write("\n====================\nMidterms Score must be 0 - 100\n====================\n\n");
                    continue;
                }
                else
                {
                    break;
                }

            }

            percentage = (score / 100) * 100;
            return percentage;
        }

        static double finals()
        {
            string input;
            bool access;
            double percentage, score;

            while (true)
            {
                Console.Write("Finals  Score (?/100): ");
                input = Console.ReadLine();

                access = double.TryParse(input, out score) && score >= 0 && score <= 100;

                if (!access)
                {
                    Console.Write("\n====================\nFinals Score must be 0 - 100\n====================\n\n");
                    continue;
                }
                else
                {
                    break;
                }

            }

            percentage = (score / 100) * 100;
            return percentage;
        }

        static double project()
        {
            string input;
            bool access;
            double percentage, score;

            while (true)
            {
                Console.Write("Project Score (?/100): ");
                input = Console.ReadLine();

                access = double.TryParse(input, out score) && score >= 0 && score <= 100;

                if (!access)
                {
                    Console.Write("\n====================\nProject Score must be 0 - 100\n====================\n\n");
                    continue;
                }
                else
                {
                    break;
                }

            }

            percentage = (score / 100) * 100;
            return percentage;
        }

        static double totalScore(double quizOne, double attendance, double midterms, double finals, double project)
        {
            double totalScore = (quizOne * 0.20) + (attendance * 0.10) + (midterms * 0.25) + (finals * 0.25) + (project * 0.20);
            return totalScore;
        }

        static void showStudentsGrade(double[,] studentGrade, string[] studentName)
        {

            //Console.WriteLine("Student Name          |Quiz One       |Attendance     |Midterms       |Finals         |Project        |Total          ");

            for (int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine("Student Name: " + studentName[i]);
                Console.WriteLine("Quiz One: " + studentGrade[i, 0] + "%");
                Console.WriteLine("Attendance: " + studentGrade[i, 1] + "%");
                Console.WriteLine("Midterms: " + studentGrade[i, 2] + "%");
                Console.WriteLine("Finals: " + studentGrade[i, 3] + "%");
                Console.WriteLine("Project: " + studentGrade[i, 4] + "%");
                Console.WriteLine("Total Score: " + studentGrade[i, 5] + "%");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string[] studentName =
            {
                "John Carlo Nayan",
                "Lebron James",
            };

            // columns: 0 Quiz1, 1 Attendance, 2 Midterms, 3 Finals, 4 Project, 5 Total
            double[,] studentGrade = new double[studentName.Length, 6];

            for (int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine(studentName[i] + "'s Quiz One");
                studentGrade[i, 0] = quizOne();

                Console.WriteLine(studentName[i] + "'s Attendance");
                studentGrade[i, 1] = attendance();

                Console.WriteLine(studentName[i] + "'s Midterms");
                studentGrade[i, 2] = midterms();

                Console.WriteLine(studentName[i] + "'s Finals");
                studentGrade[i, 3] = finals();

                Console.WriteLine(studentName[i] + "'s Project");
                studentGrade[i, 4] = project();

                studentGrade[i, 5] = totalScore(
                    studentGrade[i, 0],
                    studentGrade[i, 1],
                    studentGrade[i, 2],
                    studentGrade[i, 3],
                    studentGrade[i, 4]
                );

                Console.WriteLine(); // space after each student input
            }

            showStudentsGrade(studentGrade, studentName);
        }
    }
}