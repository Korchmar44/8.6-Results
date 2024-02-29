using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_HW_03.Services
{
    public static class MyPath
    {
        
        public static string ItemPath { get; private set; } // Представляет путь элемента.

        public static string GetMyPath(string path1)
        {
            ItemPath = Path.Combine(path1);
            return ItemPath;
        }

        public static string GetMyPath(string path1, string path2)
        {
            ItemPath = Path.Combine(path1, path2);
            return ItemPath;
        }
    }
}
