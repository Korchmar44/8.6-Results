using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task_1_HW_03.Services
{
    public static class FileServices
    {
        /**
         * Проверяет существование директории или файла по указанному пути.
         * @param {string} path - Путь к директории или файлу.
         * @return {bool} - True, если директория или файл существуют, в противном случае - false.
         */
        public static bool CheckDir(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return false;
            }
            else if (!Directory.Exists(path))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void DeleteItem(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("Файл успешно удален"); // File successfully deleted
                }
                else if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    Console.WriteLine("Каталог с файлами успешно удален"); // Directory with files successfully deleted
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}"); // Error: {e}
            }
        }

        public static void DeleteUnusedFilesAndFolders(string path)
        {
            if (!CheckDir(path))
            {
                Console.WriteLine("Директория не существует");
                return;
            }

            // Создаем объект DirectoryInfo на основе указанного пути
            DirectoryInfo dir = new DirectoryInfo(path);

            // Перебираем каждый файл в каталоге
            foreach (FileInfo file in dir.GetFiles())
            {
                // Проверяем, было ли последнее время доступа к файлу более 30 минут назад
                if (DateTime.Now - file.LastAccessTime > TimeSpan.FromMinutes(30))
                {
                    try
                    {
                        // Пытаемся удалить файл
                        file.Delete();
                        Console.WriteLine("Файл успешно удален");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Если нет доступа к файлу, выводим сообщение об ошибке
                        Console.WriteLine("Нет доступа к файлу");
                    }
                }
                else
                {
                    // Если нет, выводим сообщение о том, что файл не был удален, и отображаем его последнее время доступа
                    Console.WriteLine($"Файл не удален, последнее время доступа: {file.LastAccessTime}");
                }
            }

            // Перебираем каждый подкаталог в каталоге
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                // Проверяем, было ли последнее время доступа к подкаталогу более 30 минут назад
                if (DateTime.Now - subDir.LastAccessTime > TimeSpan.FromMinutes(30))
                {
                    try
                    {
                        // Пытаемся удалить подкаталог и все его содержимое
                        subDir.Delete(true);
                        Console.WriteLine("Каталог с файлами успешно удален");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Если нет доступа к подкаталогу, выводим сообщение об ошибке
                        Console.WriteLine("Нет доступа к каталогу");
                    }
                }
                else
                {
                    // Если нет, выводим сообщение о том, что подкаталог не был удален, и отображаем его последнее время доступа
                    Console.WriteLine($"Каталог не удален, последнее время доступа: {subDir.LastAccessTime}");
                }
            }

            // Удаляем исходный каталог, если он пуст
            if (dir.GetFileSystemInfos().Length == 0)
            {
                try
                {
                    // Пытаемся удалить исходный каталог
                    dir.Delete();
                    Console.WriteLine("Исходный каталог успешно удален");
                }
                catch (UnauthorizedAccessException)
                {
                    // Если нет доступа к исходному каталогу, выводим сообщение об ошибке
                    Console.WriteLine("Нет доступа к исходному каталогу");
                }
            }
        }

        public static string CreateUnusedFilesAndFolders(string test_directory)
        {
            // Устанавливаем тестовую директорию
            string testDirectory = test_directory;
            DirectoryInfo dir = new DirectoryInfo(testDirectory);
            dir.Create();

            // Создаем тестовый файл
            string testFilePath = Path.Combine(testDirectory, "testFile.txt");
            File.Create(testFilePath).Close();

            // Создаем тестовую поддиректорию
            string testSubDirectoryPath = Path.Combine(testDirectory, "TestSubDirectory");
            DirectoryInfo subDir = new DirectoryInfo(testSubDirectoryPath);
            subDir.Create();

            // Устанавливаем время последнего доступа более чем 30 минут назад
            File.SetLastAccessTime(testFilePath, DateTime.Now - TimeSpan.FromMinutes(31));
            Directory.SetLastAccessTime(testSubDirectoryPath, DateTime.Now - TimeSpan.FromMinutes(31));

            return testDirectory;
        }
    }
}
