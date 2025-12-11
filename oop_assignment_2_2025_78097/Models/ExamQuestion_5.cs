using System;
using System.Globalization;

namespace oop_assignment_2_2025_78097.Models
{
    public static class ExamQuestion_5
    {
        public static void Run()
        {
            Console.WriteLine("Exam Question 5 executed.");

            // 5.A – format a given DateTime as dd/MM/yyyy
            var sampleDate = new DateTime(2025, 7, 4);
            Console.WriteLine("5A: " + FormatDateShort(sampleDate));

            // 5.B – current system time in 12-hour format with AM/PM
            Console.WriteLine("5B (current time): " + GetCurrentTime12Hour());

            // 5.C – parse "2025-11-30" and format as full long date
            Console.WriteLine("5C: " + FormatLongDate("2025-11-30"));
        }

        // 5.A – dd/MM/yyyy, e.g. 04/07/2025
        public static string FormatDateShort(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        // Testable version: given a DateTime, format as 12-hour with AM/PM
        // Example: 2:15 PM -> "02:15 PM"
        public static string FormatTime12Hour(DateTime time)
        {
            return time.ToString("hh:mm tt");
        }

        // 5.B – wrapper that uses the current system time
        public static string GetCurrentTime12Hour()
        {
            return FormatTime12Hour(DateTime.Now);
        }

        // 5.C – parse "yyyy-MM-dd" and output
        // "Sunday, 30 November 2025"
        public static string FormatLongDate(string isoDateString)
        {
            var inputFormat = "yyyy-MM-dd";
            var culture = CultureInfo.InvariantCulture;

            DateTime date = DateTime.ParseExact(isoDateString, inputFormat, culture);
            return date.ToString("dddd, dd MMMM yyyy", culture);
        }
    }
}
