using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_HW_03.Models
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AverageScore { get; set; }    

        public override string ToString()
        {
            return $"Имя: {Name}, Группа: {Group}, Дата рождения: {DateOfBirth.ToShortDateString()}, Средний балл: {AverageScore}";
        }
    }

}
