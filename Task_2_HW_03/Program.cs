using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_HW_03.Services;

namespace Task_2_HW_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Определяем путь
            string path = @"C:\Users\amigo\Pictures";
            
            // Задаем путь для дальнейшего использования
            MyPath.GetMyPath(path);

            // Выводим информацию о пути и его размере
            CounterSize.GetFolderSize(path);
            Console.ReadKey();
        }
    }
}
