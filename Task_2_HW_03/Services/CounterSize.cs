using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_HW_03.Services
{
    public static class CounterSize
    {

        public static bool CheckDir(string folderPath)
        {
            if (String.IsNullOrEmpty(folderPath))
            {
                return false;
            }
            else if (!Directory.Exists(folderPath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void GetFolderSize(string folderPath)
        {
            long size = 0;

            if (!CheckDir(folderPath))
            {
                Console.WriteLine("Директория не существует");
                return;
            }

            try
            {
                DirectoryInfo di = new DirectoryInfo(folderPath);
                foreach (FileInfo fi in di.GetFiles("*", SearchOption.AllDirectories))
                {
                    size += fi.Length;
                }
                Console.WriteLine($"Размер папки {MyPath.ItemPath}: {size} байт");
            }
            catch (Exception e)
            {

                Console.WriteLine($"Ошибка:{ e.Message}");
            }
        }
    }
}
