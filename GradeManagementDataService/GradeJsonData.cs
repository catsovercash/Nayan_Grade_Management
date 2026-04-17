using Nayan_Grade_Management.GradeManagementModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Nayan_Grade_Management.GradeManagementDataService
{
    public class GradeJsonData : IGradeDataService
    {

        public List<Student> students = new List<Student>();

        private string _jsonFileName;

        public GradeJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/students.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {

            RetrieveDataFromJsonFile();

            if (students.Count <= 0)
            {
                students = new List<Student>
                    {
                        new Student { Id = 0, Name = "John Carlo Nayan"},
                        new Student { Id = 1, Name = "Lebron James" },
                        new Student { Id = 2, Name = "Paul George" },
                        new Student { Id = 3, Name = "Boss Atan" },
                        new Student { Id = 4, Name = "Beabadobee" }
                    };

                SaveDataToJsonFile();

            }

        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.Create(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Student>>
                    (
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , students);
            }

        }

        private void RetrieveDataFromJsonFile()
        {
            bool jsonFileExists = File.Exists(_jsonFileName);

            if (!jsonFileExists)
            {
                students = new List<Student>();
                return;
            }

            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                students = JsonSerializer.Deserialize<List<Student>>(
                    jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                ) ?? new List<Student>();
            }
        }


        public List<Student> GetAllStudents()
        {
            RetrieveDataFromJsonFile();
            return students;
        }

        public bool StudentExists(int id)
        {
            RetrieveDataFromJsonFile();

            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public Student GetStudentById(int id)
        {
            RetrieveDataFromJsonFile();

            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == id)
                {
                    return student;
                }
            }

            throw new KeyNotFoundException($"Student with ID {id} was not found.");
        }

        public void SaveStudent(Student updatedStudent)
        {
            RetrieveDataFromJsonFile();

            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == updatedStudent.Id)
                {
                    students[i] = updatedStudent;
                    break;
                }
            }

            SaveDataToJsonFile();
        }

        public void UpdateStudent(Student updatedStudent)
        {
            SaveStudent(updatedStudent);
        }

        public void DeleteStudentGrades(int id)
        {
            RetrieveDataFromJsonFile();

            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];

                if (student.Id == id)
                {
                    student.Grades = new Grades();
                    SaveDataToJsonFile();
                    break;
                }
            }
        }


    }
}
