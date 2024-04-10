using System;
using System.Data.Entity;
using System.Linq;

namespace HoGiaHuy_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EntityDBEntities())
            {
                var filteredStudents = context.Students
                    .Include(s => s.Faculty)
                    .Where(s => s.Faculty.Name == "Cong nghe thong tin" && s.Age >= 18 && s.Age <= 20)
                    .ToList();

                // Hiển thị thông tin sinh viên
                Console.WriteLine("Sinh vien thuoc khoa CNTT và co tuoi tu 18 den 20:");
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine($"Ma sinh vien: {student.StudentId}, Ten: {student.Name}, Tuoi: {student.Age}");
                }
                Console.ReadLine();
            }
        }
    }
}
