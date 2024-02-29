using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_HW_03.Models
{
    [Serializable]
    /// <summary>
    /// Представляет студента с именем, группой, датой рождения и средним баллом.
    /// </summary>
    class Student
    {
        /// <summary>
        /// Получает или задает имя студента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает группу студента.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Получает или задает дату рождения студента.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Получает или задает средний балл студента.
        /// </summary>
        public decimal AverageScore { get; set; }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString()
        {
            return $"Имя: {Name}, Группа: {Group}, Дата рождения: {DateOfBirth.ToShortDateString()}, Средний балл: {AverageScore}";
        }
    }
}
