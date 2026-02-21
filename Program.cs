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
            Console.Write("Attendance Count: (?/24):  ");
            attendanceCount = double.Parse(Console.ReadLine());

            double attendanePercentage = (attendanceCount / 24) * 100;
            return attendanePercentage;
        }

        static double midterms()
        {
            double midtermsScore;
            Console.Write("Midterms Score: (?/100):  ");
            midtermsScore = double.Parse(Console.ReadLine());

            double midtermsPercentage = (midtermsScore / 100) * 100;
            return midtermsPercentage;
        }

        static double finals()
        {
            double finalsScore;
            Console.Write("Finals Score: (?/100):  ");
            finalsScore = double.Parse(Console.ReadLine());

            double finalsPercentage = (finalsScore / 100) * 100;
            return finalsPercentage;
        }

        static double project()
        {
            double projectScore;
            Console.Write("Project Score: (?/100):  ");
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
            studentName[0] = "Student 1";
            studentName[1] = "Student 2";
            studentName[2] = "Student 3";
            studentName[3] = "Student 4";
            studentName[4] = "Student 5";
            double[,] studentGrade = new double[5, 6];

            foreach (string student in studentName)
            {

                for (int i = 0; i < 5; i++)
                {
                    Console.Write(student + "'s Quiz One\n");
                    studentGrade[i, 0] = quizOne();
                    Console.Write(student + "'s Attendance\n");
                    studentGrade[i, 1] = attendance();
                    Console.Write(student + "'s Midterms\n");
                    studentGrade[i, 2] = midterms();
                    Console.Write(student + "'s Finals\n");
                    studentGrade[i, 3] = finals();
                    Console.Write(student + "'s Project\n");
                    studentGrade[i, 4] = project();
                    studentGrade[i, 5] = totalScore(studentGrade[i, 0], studentGrade[i, 1], studentGrade[i, 2], studentGrade[i, 3], studentGrade[i, 4]);
                }
            }

            for (int i = 0; i < studentName.Length; i++)
            {
                Console.Write("Student Name:" + studentName[i]);
                Console.Write("Quiz One: " + studentGrade[i, 0] + "%\n");
                Console.Write("Attendance: " + studentGrade[i, 1] + "%\n");
                Console.Write("Midterms: " + studentGrade[i, 2] + "%\n");
                Console.Write("Finals: " + studentGrade[i, 3] + "%\n");
                Console.Write("Project: " + studentGrade[i, 4] + "%\n");
                Console.Write("Total Score: " + studentGrade[i, 5] + "%\n");
            }
        }
    }
}
