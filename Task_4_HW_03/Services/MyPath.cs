using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_HW_03.Services
{
    /// <summary>
    /// Представляет утилиту для работы с путями файлов.
    /// </summary>
    public static class MyPath
    {
        /// <summary>
        /// Получает или задает путь элемента.
        /// </summary>
        public static string ItemPath { get; private set; }

        /// <summary>
        /// Комбинирует указанный путь path1 в путь элемента.
        /// </summary>
        /// <param name="path1">Первый путь для объединения.</param>
        /// <returns>Объединенный путь.</returns>
        public static string GetMyPath(string path1)
        {
            ItemPath = Path.Combine(path1);
            return ItemPath;
        }

        /// <summary>
        /// Комбинирует указанные пути path1 и path2 в путь элемента.
        /// </summary>
        /// <param name="path1">Первый путь для объединения.</param>
        /// <param name="path2">Второй путь для объединения.</param>
        /// <returns>Объединенный путь.</returns>
        public static string GetMyPath(string path1, string path2)
        {
            ItemPath = Path.Combine(path1, path2);
            return ItemPath;
        }
    }
}
