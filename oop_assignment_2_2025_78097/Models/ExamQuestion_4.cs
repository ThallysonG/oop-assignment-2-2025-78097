using System;
using System.Globalization;

namespace oop_assignment_2_2025_78097.Models
{
    public static class ExamQuestion_4
    {
        public static void Run()
        {
            Console.WriteLine("Exam Question 4 executed.");

            Console.WriteLine("4A: 42 -> " + FormatAsFiveDigits(42));
            Console.WriteLine("4B: 1234.5m -> " + FormatPrice(1234.5m));
        }

       
        public static string FormatAsFiveDigits(int number)
        {
            return number.ToString("D5");
        }

        
        public static string FormatPrice(decimal price)
        {
           
            var culture = new CultureInfo("en-IE");
            return price.ToString("C2", culture);
        }
    }
}
