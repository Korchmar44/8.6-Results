using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Task_4_HW_03.Models;

namespace Task_4_HW_03.Services
{
    static class StudentService
    {
        public static void SaveStudentsToGroupedBinaryFiles(List<Student> students, string outputDirectory)
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            foreach (var group in students.GroupBy(s => s.Group))
            {
                string groupFileName = Path.Combine(outputDirectory, $"{group.Key}.bin");
                using (Stream stream = new FileStream(groupFileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, group.ToList());
                }
            }
        }

        private static List<Student> ReadStudentsFromBinaryFile(string filePath)
        {
            List<Student> students = null;

            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    students = (List<Student>)formatter.Deserialize(fileStream);
                }
            }

            return students;
        }

        public static void PrintBinFile(string filePath)
        {
            List<Student> students = ReadStudentsFromBinaryFile(filePath);

            if (students != null)
            {
                students = students.OrderByDescending(s => s.AverageScore).ToList();
                Console.WriteLine($"Содержимое бинарного файла группы: {students.GroupBy(s => s.Group).First().Key}");
                foreach (var student in students)
                {
                    Console.WriteLine($"Имя: {student.Name}, Дата рождения: {student.DateOfBirth}, Средний балл: {student.AverageScore}");
                }
            }
            else
            {
                Console.WriteLine("Не удалось прочитать студентов из бинарного файла. Пожалуйста, убедитесь, что путь к файлу указан правильно.");
            }
        }
    }
}
