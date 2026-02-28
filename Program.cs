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

        static void showAllStudentNames(string[] studentName)
        {
            for(int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine(studentName[i]);
            }
        }

        static void Main(string[] args)
        {

            bool isRunning = true;

            string[] studentName =
            {
                "John Carlo Nayan",
                "Lebron James",
            };

            double[,] studentGrade = new double[studentName.Length, 6];

            while (isRunning)
            {

                Console.Write("0.Exit\n1. Show All Student\n2.Set Student Grade\n3. Show Student Grade\nChoice: ");
                string choice = Console.ReadLine();

                bool access = int.TryParse(choice, out int userChoice) && userChoice >= 0 && userChoice <= 3;

                if (!access)
                {
                    Console.Write("\nInvalid\n");
                }
                else
                {
                    switch (userChoice)
                    {

                        case 0:
                            isRunning = false;
                            break;

                        case 1:
                            showAllStudentNames(studentName);
                            break;

                        case 2:
                            Console.Write("Student ID Number: ");
                            String studentIdNumber = Console.ReadLine();

                            bool accessStudentId = int.TryParse(studentIdNumber, out int userStudentIdNumber) && userStudentIdNumber >= 0 && userStudentIdNumber <= 1;

                            if (!accessStudentId)
                            {
                                Console.WriteLine("Invalid ID Number");
                            }
                            else
                            {
                                Console.WriteLine(studentName[userStudentIdNumber] + "'s Quiz One");
                                studentGrade[userStudentIdNumber, 0] = quizOne();

                                Console.WriteLine(studentName[userStudentIdNumber] + "'s Attendance");
                                studentGrade[userStudentIdNumber, 1] = attendance();

                                Console.WriteLine(studentName[userStudentIdNumber] + "'s Midterms");
                                studentGrade[userStudentIdNumber, 2] = midterms();

                                Console.WriteLine(studentName[userStudentIdNumber] + "'s Finals");
                                studentGrade[userStudentIdNumber, 3] = finals();

                                Console.WriteLine(studentName[userStudentIdNumber] + "'s Project");
                                studentGrade[userStudentIdNumber, 4] = project();
                            }

                                break;

                        case 3:

                            Console.Write("Student ID Number: ");
                            String studentIdNumber2 = Console.ReadLine();

                            bool accessStudentId2 = int.TryParse(studentIdNumber2, out int userStudentIdNumber2) && userStudentIdNumber2 >= 0 && userStudentIdNumber2 <= 1;

                            if (!accessStudentId2)
                            {
                                Console.WriteLine("Invalid ID Number");
                            }
                            else
                            {

                                Console.WriteLine("Student Name: " + studentName[userStudentIdNumber2]);
                                Console.WriteLine("Quiz One: " + studentGrade[userStudentIdNumber2, 0] + "%");
                                Console.WriteLine("Attendance: " + studentGrade[userStudentIdNumber2, 1] + "%");
                                Console.WriteLine("Midterms: " + studentGrade[userStudentIdNumber2, 2] + "%");
                                Console.WriteLine("Finals: " + studentGrade[userStudentIdNumber2, 3] + "%");
                                Console.WriteLine("Project: " + studentGrade[userStudentIdNumber2, 4] + "%");
                                Console.WriteLine("Total Score: " + studentGrade[userStudentIdNumber2, 5] + "%");
                                Console.WriteLine();

                            }

                            break;
                            }
                    }
                }

            }

        }
    }
