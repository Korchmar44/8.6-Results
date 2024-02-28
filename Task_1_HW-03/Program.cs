using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1_HW_03.Services;

namespace Task_1_HW_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Определяем путь
            var path = @"C:\Users\amigo\Documents\TestDirectory";

            // Создаем неиспользуемые файлы и папки
            FileServices.CreateUnusedFilesAndFolders(path);

            // Задаем путь для дальнейшего использования
            MyPath.GetMyPath(path);

            // Удаляем неиспользуемые файлы и папки, используя указанный путь
            FileServices.DeleteUnusedFilesAndFolders(MyPath.ItemPath);

            // Ждем ввода пользователя перед выходом
            Console.ReadKey();
        }
    }
}
