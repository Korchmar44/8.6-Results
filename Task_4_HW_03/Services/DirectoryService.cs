using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_HW_03.Services
{
    /// <summary>
    /// Предоставляет методы для работы с каталогами.
    /// </summary>
    static class DirectoryService
    {
        /// <summary>
        /// Создает новый каталог или очищает существующий каталог.
        /// </summary>
        /// <param name="directoryName">Имя каталога для создания или очистки.</param>
        public static void CreateOrClearDirectory(string directoryName)
        {
            try
            {
                if (Directory.Exists(directoryName))
                {
                    DirectoryInfo directory = new DirectoryInfo(directoryName);
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                    {
                        subDirectory.Delete(true);
                    }
                    Console.WriteLine($"Каталог {directoryName} был создан ранее и успешно очищен");
                }
                else
                {
                    Directory.CreateDirectory(directoryName);
                    Console.WriteLine($"Каталог {directoryName} успешно создан");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
