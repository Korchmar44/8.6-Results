using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_HW_03.Services
{
    static class DirectoryService
    {
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
                    Console.WriteLine($"Директория {directoryName} была создана ранее и успешно очищена");
                }
                else
                {
                    Directory.CreateDirectory(directoryName);
                    Console.WriteLine($"Директория {directoryName} успешно создана");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
