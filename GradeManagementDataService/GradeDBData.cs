using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Nayan_Grade_Management.GradeManagementModels;

namespace Nayan_Grade_Management.GradeManagementDataService
{
    public class GradeDBData : IGradeDataService
    {
        private readonly string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=GradeManagement;Integrated Security=True;TrustServerCertificate=True";

        public GradeDBData()
        {
            AddSeeds();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string query = @"
                SELECT
                    s.Id,
                    s.Name,
                    g.QuizOne,
                    g.Attendance,
                    g.Midterms,
                    g.Finals,
                    g.Project,
                    g.TotalScore
                FROM Students s
                LEFT JOIN Grades g ON s.Id = g.StudentId
                ORDER BY s.Id";

            using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                students.Add(MapStudent(reader));
            }

            return students;
        }

        public bool StudentExists(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string query = "SELECT COUNT(1) FROM Students WHERE Id = @Id";

            using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);

            int count = (int)sqlCommand.ExecuteScalar()!;
            return count > 0;
        }

        public Student GetStudentById(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string query = @"
                SELECT
                    s.Id,
                    s.Name,
                    g.QuizOne,
                    g.Attendance,
                    g.Midterms,
                    g.Finals,
                    g.Project,
                    g.TotalScore
                FROM Students s
                LEFT JOIN Grades g ON s.Id = g.StudentId
                WHERE s.Id = @Id";

            using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                return MapStudent(reader);
            }

            throw new KeyNotFoundException($"Student with ID {id} was not found.");
        }

        public void SaveStudent(Student updatedStudent)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            if (!StudentExists(updatedStudent.Id))
            {
                string insertStudentQuery = @"
                    INSERT INTO Students (Id, Name)
                    VALUES (@Id, @Name)";

                using SqlCommand insertStudentCommand = new SqlCommand(insertStudentQuery, sqlConnection);
                insertStudentCommand.Parameters.AddWithValue("@Id", updatedStudent.Id);
                insertStudentCommand.Parameters.AddWithValue("@Name", updatedStudent.Name);
                insertStudentCommand.ExecuteNonQuery();
            }
            else
            {
                string updateStudentQuery = @"
                    UPDATE Students
                    SET Name = @Name
                    WHERE Id = @Id";

                using SqlCommand updateStudentCommand = new SqlCommand(updateStudentQuery, sqlConnection);
                updateStudentCommand.Parameters.AddWithValue("@Id", updatedStudent.Id);
                updateStudentCommand.Parameters.AddWithValue("@Name", updatedStudent.Name);
                updateStudentCommand.ExecuteNonQuery();
            }

            string mergeGradesQuery = @"
                MERGE Grades AS target
                USING (SELECT @StudentId AS StudentId) AS source
                ON target.StudentId = source.StudentId
                WHEN MATCHED THEN
                    UPDATE SET
                        QuizOne = @QuizOne,
                        Attendance = @Attendance,
                        Midterms = @Midterms,
                        Finals = @Finals,
                        Project = @Project,
                        TotalScore = @TotalScore
                WHEN NOT MATCHED THEN
                    INSERT (StudentId, QuizOne, Attendance, Midterms, Finals, Project, TotalScore)
                    VALUES (@StudentId, @QuizOne, @Attendance, @Midterms, @Finals, @Project, @TotalScore);";

            using SqlCommand mergeGradesCommand = new SqlCommand(mergeGradesQuery, sqlConnection);
            mergeGradesCommand.Parameters.AddWithValue("@StudentId", updatedStudent.Id);
            mergeGradesCommand.Parameters.AddWithValue("@QuizOne", updatedStudent.Grades.QuizOne);
            mergeGradesCommand.Parameters.AddWithValue("@Attendance", updatedStudent.Grades.Attendance);
            mergeGradesCommand.Parameters.AddWithValue("@Midterms", updatedStudent.Grades.Midterms);
            mergeGradesCommand.Parameters.AddWithValue("@Finals", updatedStudent.Grades.Finals);
            mergeGradesCommand.Parameters.AddWithValue("@Project", updatedStudent.Grades.Project);
            mergeGradesCommand.Parameters.AddWithValue("@TotalScore", updatedStudent.Grades.TotalScore);
            mergeGradesCommand.ExecuteNonQuery();
        }

        private void AddSeeds()
        {
            List<Student> existing = GetAllStudents();

            if (existing.Count == 0)
            {
                Student studentOne = new Student { Id = 0, Name = "John Carlo Nayan" };
                Student studentTwo = new Student { Id = 1, Name = "Lebron James" };
                Student studentThree = new Student { Id = 2, Name = "Paul George" };
                Student studentFour = new Student { Id = 3, Name = "Boss Atan" };
                Student studentFive = new Student { Id = 4, Name = "Beabadobee" };

                SaveStudent(studentOne);
                SaveStudent(studentTwo);
                SaveStudent(studentThree);
                SaveStudent(studentFour);
                SaveStudent(studentFive);
            }
        }

        private static Student MapStudent(SqlDataReader reader)
        {
            return new Student
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Grades = new Grades
                {
                    QuizOne = GetDoubleValue(reader, "QuizOne"),
                    Attendance = GetDoubleValue(reader, "Attendance"),
                    Midterms = GetDoubleValue(reader, "Midterms"),
                    Finals = GetDoubleValue(reader, "Finals"),
                    Project = GetDoubleValue(reader, "Project"),
                    TotalScore = GetDoubleValue(reader, "TotalScore")
                }
            };
        }

        private static double GetDoubleValue(SqlDataReader reader, string columnName)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(ordinal))
            {
                return 0;
            }

            return Convert.ToDouble(reader.GetValue(ordinal));
        }
    }
}
