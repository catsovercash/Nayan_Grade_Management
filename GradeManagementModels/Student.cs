namespace Nayan_Grade_Management.GradeManagementModels
{
    internal class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Grades Grades { get; set; } = new Grades();
    }
}
