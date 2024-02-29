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
    /// <summary>
    /// Предоставляет методы для сохранения и чтения данных студентов в группированные двоичные файлы.
    /// </summary>
    static class StudentService
    {
        /// <summary>
        /// Сохраняет список студентов в группированные двоичные файлы в указанном выходном каталоге.
        /// </summary>
        /// <param name="students">Список студентов, которые будут сохранены.</param>
        /// <param name="outputDirectory">Каталог вывода, где будут сохранены группированные двоичные файлы.</param>
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

        /// <summary>
        /// Считывает список студентов из двоичного файла.
        /// </summary>
        /// <param name="filePath">Путь к двоичному файлу.</param>
        /// <returns>Список студентов, считанный из двоичного файла, или null, если файл не существует.</returns>
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

        /// <summary>
        /// Выводит содержимое двоичного файла, содержащего данные студентов.
        /// </summary>
        /// <param name="filePath">Путь к двоичному файлу.</param>
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
