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

        // 4.A – always 5 digits, leading zeros
        // Example: 42 -> "00042"
        public static string FormatAsFiveDigits(int number)
        {
            return number.ToString("D5");
        }

        // 4.B – format price:
        // - exactly two decimal places
        // - includes € symbol
        // - includes thousands separators
        // Example: 1234.5m -> "€1,234.50"
        public static string FormatPrice(decimal price)
        {
            // Use Irish/Euro formatting
            var culture = new CultureInfo("en-IE");
            return price.ToString("C2", culture);
        }
    }
}
