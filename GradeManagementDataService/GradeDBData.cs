using Microsoft.Data.SqlClient;
using Nayan_Grade_Management.GradeManagementModels;
using System;
using System.Collections.Generic;

namespace Nayan_Grade_Management.GradeManagementDataService
{
    public class GradeDBData : IGradeDataService
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=GradeManagement;Integrated Security=True;TrustServerCertificate=True";

        private SqlConnection sqlConnection;

        public GradeDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            string selectStatement =
                "SELECT s.Id, s.Name, g.QuizOne, g.Attendance, g.Midterms, g.Finals, g.Project, g.TotalScore " +
                "FROM Students s " +
                "LEFT JOIN Grades g ON s.Id = g.StudentId " +
                "ORDER BY s.Id";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString() ?? string.Empty;

                student.Grades = new Grades();

                if (reader["QuizOne"] != DBNull.Value)
                {
                    student.Grades.QuizOne = Convert.ToDouble(reader["QuizOne"]);
                }

                if (reader["Attendance"] != DBNull.Value)
                {
                    student.Grades.Attendance = Convert.ToDouble(reader["Attendance"]);
                }

                if (reader["Midterms"] != DBNull.Value)
                {
                    student.Grades.Midterms = Convert.ToDouble(reader["Midterms"]);
                }

                if (reader["Finals"] != DBNull.Value)
                {
                    student.Grades.Finals = Convert.ToDouble(reader["Finals"]);
                }

                if (reader["Project"] != DBNull.Value)
                {
                    student.Grades.Project = Convert.ToDouble(reader["Project"]);
                }

                if (reader["TotalScore"] != DBNull.Value)
                {
                    student.Grades.TotalScore = Convert.ToDouble(reader["TotalScore"]);
                }

                students.Add(student);
            }

            sqlConnection.Close();

            return students;
        }

        public bool StudentExists(int id)
        {
            string selectStatement = "SELECT Id, Name FROM Students WHERE Id = @Id";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            bool studentExists = false;

            while (reader.Read())
            {
                studentExists = true;
            }

            sqlConnection.Close();

            return studentExists;
        }

        public Student GetStudentById(int id)
        {
            string selectStatement =
                "SELECT s.Id, s.Name, g.QuizOne, g.Attendance, g.Midterms, g.Finals, g.Project, g.TotalScore " +
                "FROM Students s " +
                "LEFT JOIN Grades g ON s.Id = g.StudentId " +
                "WHERE s.Id = @Id";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            Student student = new Student();
            student.Grades = new Grades();

            bool studentExists = false;

            while (reader.Read())
            {
                studentExists = true;

                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString() ?? string.Empty;

                if (reader["QuizOne"] != DBNull.Value)
                {
                    student.Grades.QuizOne = Convert.ToDouble(reader["QuizOne"]);
                }

                if (reader["Attendance"] != DBNull.Value)
                {
                    student.Grades.Attendance = Convert.ToDouble(reader["Attendance"]);
                }

                if (reader["Midterms"] != DBNull.Value)
                {
                    student.Grades.Midterms = Convert.ToDouble(reader["Midterms"]);
                }

                if (reader["Finals"] != DBNull.Value)
                {
                    student.Grades.Finals = Convert.ToDouble(reader["Finals"]);
                }

                if (reader["Project"] != DBNull.Value)
                {
                    student.Grades.Project = Convert.ToDouble(reader["Project"]);
                }

                if (reader["TotalScore"] != DBNull.Value)
                {
                    student.Grades.TotalScore = Convert.ToDouble(reader["TotalScore"]);
                }
            }

            sqlConnection.Close();

            if (!studentExists)
            {
                throw new KeyNotFoundException($"Student with ID {id} was not found.");
            }

            return student;
        }

        public void SaveStudent(Student updatedStudent)
        {
            bool studentExists = StudentExists(updatedStudent.Id);

            if (!studentExists)
            {
                string insertStudentStatement =
                    "INSERT INTO Students (Id, Name) VALUES (@Id, @Name)";

                SqlCommand insertStudentCommand = new SqlCommand(insertStudentStatement, sqlConnection);
                insertStudentCommand.Parameters.AddWithValue("@Id", updatedStudent.Id);
                insertStudentCommand.Parameters.AddWithValue("@Name", updatedStudent.Name);

                sqlConnection.Open();
                insertStudentCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                string updateStudentStatement =
                    "UPDATE Students SET Name = @Name WHERE Id = @Id";

                SqlCommand updateStudentCommand = new SqlCommand(updateStudentStatement, sqlConnection);
                updateStudentCommand.Parameters.AddWithValue("@Id", updatedStudent.Id);
                updateStudentCommand.Parameters.AddWithValue("@Name", updatedStudent.Name);

                sqlConnection.Open();
                updateStudentCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            bool gradeRecordExists = GradeRecordExists(updatedStudent.Id);

            if (!gradeRecordExists)
            {
                string insertGradeStatement =
                    "INSERT INTO Grades (StudentId, QuizOne, Attendance, Midterms, Finals, Project, TotalScore) " +
                    "VALUES (@StudentId, @QuizOne, @Attendance, @Midterms, @Finals, @Project, @TotalScore)";

                SqlCommand insertGradeCommand = new SqlCommand(insertGradeStatement, sqlConnection);
                insertGradeCommand.Parameters.AddWithValue("@StudentId", updatedStudent.Id);
                insertGradeCommand.Parameters.AddWithValue("@QuizOne", updatedStudent.Grades.QuizOne);
                insertGradeCommand.Parameters.AddWithValue("@Attendance", updatedStudent.Grades.Attendance);
                insertGradeCommand.Parameters.AddWithValue("@Midterms", updatedStudent.Grades.Midterms);
                insertGradeCommand.Parameters.AddWithValue("@Finals", updatedStudent.Grades.Finals);
                insertGradeCommand.Parameters.AddWithValue("@Project", updatedStudent.Grades.Project);
                insertGradeCommand.Parameters.AddWithValue("@TotalScore", updatedStudent.Grades.TotalScore);

                sqlConnection.Open();
                insertGradeCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                string updateGradeStatement =
                    "UPDATE Grades SET QuizOne = @QuizOne, Attendance = @Attendance, Midterms = @Midterms, " +
                    "Finals = @Finals, Project = @Project, TotalScore = @TotalScore WHERE StudentId = @StudentId";

                SqlCommand updateGradeCommand = new SqlCommand(updateGradeStatement, sqlConnection);
                updateGradeCommand.Parameters.AddWithValue("@StudentId", updatedStudent.Id);
                updateGradeCommand.Parameters.AddWithValue("@QuizOne", updatedStudent.Grades.QuizOne);
                updateGradeCommand.Parameters.AddWithValue("@Attendance", updatedStudent.Grades.Attendance);
                updateGradeCommand.Parameters.AddWithValue("@Midterms", updatedStudent.Grades.Midterms);
                updateGradeCommand.Parameters.AddWithValue("@Finals", updatedStudent.Grades.Finals);
                updateGradeCommand.Parameters.AddWithValue("@Project", updatedStudent.Grades.Project);
                updateGradeCommand.Parameters.AddWithValue("@TotalScore", updatedStudent.Grades.TotalScore);

                sqlConnection.Open();
                updateGradeCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdateStudent(Student updatedStudent)
        {
            SaveStudent(updatedStudent);
        }

        public void DeleteStudentGrades(int id)
        {
            bool gradeRecordExists = GradeRecordExists(id);

            if (!gradeRecordExists)
            {
                string insertGradeStatement =
                    "INSERT INTO Grades (StudentId, QuizOne, Attendance, Midterms, Finals, Project, TotalScore) " +
                    "VALUES (@StudentId, 0, 0, 0, 0, 0, 0)";

                SqlCommand insertGradeCommand = new SqlCommand(insertGradeStatement, sqlConnection);
                insertGradeCommand.Parameters.AddWithValue("@StudentId", id);

                sqlConnection.Open();
                insertGradeCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                string resetGradeStatement =
                    "UPDATE Grades SET QuizOne = 0, Attendance = 0, Midterms = 0, Finals = 0, " +
                    "Project = 0, TotalScore = 0 WHERE StudentId = @StudentId";

                SqlCommand resetGradeCommand = new SqlCommand(resetGradeStatement, sqlConnection);
                resetGradeCommand.Parameters.AddWithValue("@StudentId", id);

                sqlConnection.Open();
                resetGradeCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private bool GradeRecordExists(int studentId)
        {
            string selectStatement = "SELECT StudentId FROM Grades WHERE StudentId = @StudentId";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@StudentId", studentId);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            bool gradeRecordExists = false;

            while (reader.Read())
            {
                gradeRecordExists = true;
            }

            sqlConnection.Close();

            return gradeRecordExists;
        }

        private void AddSeeds()
        {
            List<Student> students = GetAllStudents();
            bool hasNoStudents = students.Count == 0;

            if (hasNoStudents)
            {
                Student studentOne = new Student();
                studentOne.Id = 0;
                studentOne.Name = "John Carlo Nayan";

                Student studentTwo = new Student();
                studentTwo.Id = 1;
                studentTwo.Name = "Lebron James";

                Student studentThree = new Student();
                studentThree.Id = 2;
                studentThree.Name = "Paul George";

                Student studentFour = new Student();
                studentFour.Id = 3;
                studentFour.Name = "Boss Atan";

                Student studentFive = new Student();
                studentFive.Id = 4;
                studentFive.Name = "Beabadobee";

                SaveStudent(studentOne);
                SaveStudent(studentTwo);
                SaveStudent(studentThree);
                SaveStudent(studentFour);
                SaveStudent(studentFive);
            }
        }
    }
}
