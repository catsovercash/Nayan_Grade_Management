using System;

namespace Nayan_Grade_Management
{
    internal class Program
    {
        static double quizOne()
        {
            double quizOneScore;
            Console.Write("Quiz 1 Score (?/20):  ");
            quizOneScore = double.Parse(Console.ReadLine());

            double quizOnePercentage = (quizOneScore / 20) * 100;
            return quizOnePercentage;
        }

        static double attendance()
        {
            double attendanceCount;
            Console.Write("Attendance Count (?/24):  ");
            attendanceCount = double.Parse(Console.ReadLine());

            double attendancePercentage = (attendanceCount / 24) * 100;
            return attendancePercentage;
        }

        static double midterms()
        {
            double midtermsScore;
            Console.Write("Midterms Score (?/100):  ");
            midtermsScore = double.Parse(Console.ReadLine());

            double midtermsPercentage = (midtermsScore / 100) * 100;
            return midtermsPercentage;
        }

        static double finals()
        {
            double finalsScore;
            Console.Write("Finals Score (?/100):  ");
            finalsScore = double.Parse(Console.ReadLine());

            double finalsPercentage = (finalsScore / 100) * 100;
            return finalsPercentage;
        }

        static double project()
        {
            double projectScore;
            Console.Write("Project Score (?/100):  ");
            projectScore = double.Parse(Console.ReadLine());

            double projectPercentage = (projectScore / 100) * 100;
            return projectPercentage;
        }

        static double totalScore(double quizOne, double attendance, double midterms, double finals, double project)
        {
            double totalScore = (quizOne * 0.20) + (attendance * 0.10) + (midterms * 0.25) + (finals * 0.25) + (project * 0.20);
            return totalScore;
        }

        static void Main(string[] args)
        {
            string[] studentName = new string[5];
            studentName[0] = "John Carlo Nayan";
            studentName[1] = "Lebron James";
            studentName[2] = "Paul George";
            studentName[3] = "Stephen Curry";
            studentName[4] = "Boss Atan";

            // columns: 0 Quiz1, 1 Attendance, 2 Midterms, 3 Finals, 4 Project, 5 Total
            double[,] studentGrade = new double[5, 6];

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

            // print results
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
    }
}