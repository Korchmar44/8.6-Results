using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_4_HW_03.Models;
using Task_4_HW_03.Services;

namespace Task_4_HW_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> Students = new List<Student> 
            {
                new Student { Name = "Жульен", Group = "G1", DateOfBirth = new DateTime(2001, 10, 22), AverageScore = 3.3M },
                new Student { Name = "Боб", Group = "G1", DateOfBirth = new DateTime(1999, 5, 25), AverageScore = 4.5M},
                new Student { Name = "Лилия", Group = "F2", DateOfBirth = new DateTime(1999, 1, 11), AverageScore = 5M},
                new Student { Name = "Роза", Group = "F2", DateOfBirth = new DateTime(1989, 9, 19), AverageScore = 3.7M}
            };
            MyPath.GetMyPath(@"C:\Users\amigo\Desktop\Students");
            DirectoryService.CreateOrClearDirectory(MyPath.ItemPath);
            StudentService.SaveStudentsToGroupedBinaryFiles(Students, MyPath.ItemPath);
            Console.WriteLine();

            MyPath.GetMyPath(@"C:\Users\amigo\Desktop\Students\G1.bin");
            StudentService.PrintBinFile(MyPath.ItemPath);
            Console.WriteLine();

            MyPath.GetMyPath(@"C:\Users\amigo\Desktop\Students\F2.bin");
            StudentService.PrintBinFile(MyPath.ItemPath);

            Console.ReadKey();
        }
    }
}
