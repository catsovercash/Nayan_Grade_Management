using Nayan_Grade_Management.Data;
using Nayan_Grade_Management.UI;

namespace Nayan_Grade_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                int userChoice = ConsoleUI.ReadMainMenuChoice();
                Console.WriteLine();

                switch (userChoice)
                {
                    case 0:
                        ConsoleUI.ShowExitMessage();
                        isRunning = false;
                        break;

                    case 1:
                        ConsoleUI.ShowAllStudentNames(StudentData.StudentNames);
                        Console.WriteLine();
                        break;

                    case 2:
                        int studentIdToSet = ConsoleUI.ReadStudentId(StudentData.StudentNames.Length);
                        ConsoleUI.SetStudentGrade(StudentData.StudentNames, StudentData.StudentGrades, studentIdToSet);
                        break;

                    case 3:
                        int studentIdToShow = ConsoleUI.ReadStudentId(StudentData.StudentNames.Length);
                        ConsoleUI.ShowStudentGrade(StudentData.StudentNames, StudentData.StudentGrades, studentIdToShow);
                        break;
                }
            }
        }
    }
}
