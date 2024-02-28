using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_HW_03.Services
{
    public static class MyPath
    {
        
        public static string ItemPath { get; private set; } // Представляет путь элемента.

        // Функция GetMyPath принимает строковый параметр path1 и возвращает строку, представляющую объединенный путь.
        public static string GetMyPath(string path1)
        {
            ItemPath = Path.Combine(path1);
            return ItemPath;
        }
    }
}
