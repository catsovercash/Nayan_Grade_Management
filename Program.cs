using Nayan_Grade_Management.GradeManagementAppService;
using Nayan_Grade_Management.GradeManagementModels;

namespace Nayan_Grade_Management
{
    public class Program
    {
        static void Main()
        {
            GradeAppService gradeAppService = new GradeManagementAppService.GradeAppService();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Write("0. Exit\n1. Show All Student\n2. Set Student Grade\n3. Show Student Grade\nChoice: ");
                string? choiceInput = Console.ReadLine();
                Console.WriteLine();

                if (!int.TryParse(choiceInput, out int userChoice))
                {
                    Console.Write("Invalid\n\n");
                    continue;
                }

                if (!gradeAppService.IsValidMenuChoice(userChoice))
                {
                    Console.Write("Invalid\n\n");
                    continue;
                }

                switch (userChoice)
                {
                    case 0:
                        Console.Write("Exiting...\n");
                        isRunning = false;
                        break;

                    case 1:
                        ShowAllStudentNames(gradeAppService);
                        Console.WriteLine();
                        break;

                    case 2:
                        SetStudentGrade(gradeAppService);
                        break;

                    case 3:
                        ShowStudentGrade(gradeAppService);
                        break;
                }
            }
        }

        static void ShowAllStudentNames(GradeAppService gradeAppService)
        {
            List<Student> students = gradeAppService.GetAllStudents();

            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];
                Console.WriteLine("ID " + student.Id + ". " + student.Name);
            }
        }

        static void SetStudentGrade(GradeAppService gradeAppService)
        {
            Console.Write("Student ID Number: ");
            string? studentIdInput = Console.ReadLine();

            if (!int.TryParse(studentIdInput, out int studentId))
            {
                Console.WriteLine("Invalid ID Number");
                return;
            }

            if (!gradeAppService.IsValidStudentId(studentId, gradeAppService.GetAllStudents().Count))
            {
                Console.WriteLine("Invalid ID Number");
                return;
            }

            if (!gradeAppService.StudentExists(studentId))
            {
                Console.WriteLine("Invalid ID Number");
                return;
            }

            Student student = gradeAppService.GetStudentById(studentId);

            Grades grades = new Grades();

            grades.QuizOne = PromptScore(gradeAppService,student.Name + "'s Quiz One", "Quiz 1 Score (?/20): ", 20, "Quiz 1 Score must be 0 - 20");
            grades.Attendance = PromptScore(gradeAppService, student.Name + "'s Attendance", "Attendance Score (?/24): ", 24, "Attendance Score must be 0 - 24");
            grades.Midterms = PromptScore(gradeAppService, student.Name + "'s Midterms", "Midterms Score (?/100): ", 100, "Midterms Score must be 0 - 100");
            grades.Finals = PromptScore(gradeAppService, student.Name + "'s Finals", "Finals  Score (?/100): ", 100, "Finals Score must be 0 - 100");
            grades.Project = PromptScore(gradeAppService, student.Name + "'s Project", "Project Score (?/100): ", 100, "Project Score must be 0 - 100");

            gradeAppService.SaveStudentGrades(student, grades);

        }

        static void ShowStudentGrade(GradeAppService gradeAppService)
        {
            Console.Write("Student ID Number: ");
            string? studentIdInput = Console.ReadLine();

            if (!int.TryParse(studentIdInput, out int studentId))
            {
                Console.WriteLine("Invalid ID Number");
                return;
            }

            if (!gradeAppService.IsValidStudentId(studentId, gradeAppService.GetAllStudents().Count))
            {
                Console.WriteLine("Invalid ID Number");
                return;
            }

            if (!gradeAppService.StudentExists(studentId))
            {
                Console.WriteLine("Invalid ID Number");
                return;
            }

            Student student = gradeAppService.GetStudentById(studentId);


            Console.WriteLine("Student Name: " + student.Name);
            Console.WriteLine("Quiz One: " + student.Grades.QuizOne + "%");
            Console.WriteLine("Attendance: " + student.Grades.Attendance + "%");
            Console.WriteLine("Midterms: " + student.Grades.Midterms + "%");
            Console.WriteLine("Finals: " + student.Grades.Finals + "%");
            Console.WriteLine("Project: " + student.Grades.Project + "%");
            Console.WriteLine("Total Score: " + student.Grades.TotalScore + "%");
            Console.WriteLine();
        }

        static double PromptScore(
            GradeAppService gradeAppService,
            string title,
            string prompt,
            double maxScore,
            string invalidMessage)
        {
            while (true)
            {
                Console.WriteLine(title);
                Console.Write(prompt);
                string? scoreInput = Console.ReadLine();

                if (!double.TryParse(scoreInput, out double score))
                {
                    Console.Write("\n====================\n" + invalidMessage + "\n====================\n\n");
                    continue;
                }

                if (!gradeAppService.IsValidScore(score, maxScore))
                {
                    Console.Write("\n====================\n" + invalidMessage + "\n====================\n\n");
                    continue;
                }

                double percentage = gradeAppService.ConvertScoreToPercentage(score, maxScore);
                return percentage;
            }
        }
    }
}
