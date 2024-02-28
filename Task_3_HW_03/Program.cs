using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_HW_03.Services;

namespace Task_3_HW_03
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

            // Подсчитываем исходный размер папки
            CounterSize.GetFolderSize(MyPath.ItemPath);

            // Удаляем неиспользуемые файлы и папки, используя указанный путь
            FileServices.DeleteUnusedFilesAndFolders(MyPath.ItemPath);

            // Подсчитываем текущий размер папки
            CounterSize.GetFolderSize(MyPath.ItemPath);

            // Ждем ввода пользователя перед выходом
            Console.ReadKey();
        }
    }
}
