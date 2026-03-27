using Nayan_Grade_Management.GradeManagementModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Nayan_Grade_Management.GradeManagementDataService
{
    public class GradeJsonData : IGradeDataService
    {

        public List<Student> students;

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

            using (var outputStream = File.OpenWrite(_jsonFileName))
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
            if (!File.Exists(_jsonFileName))
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
            return id >= 0 && id < students.Count;
        }

        public Student GetStudentById(int id)
        {
            RetrieveDataFromJsonFile();
            return students[id];
        }

        public void SaveStudent(Student updatedStudent)
        {
            RetrieveDataFromJsonFile();

            int index = students.FindIndex(s => s.Id == updatedStudent.Id);

            if (index >= 0)
            {
                students[index] = updatedStudent;
            }

            SaveDataToJsonFile();
        }


    }
}
