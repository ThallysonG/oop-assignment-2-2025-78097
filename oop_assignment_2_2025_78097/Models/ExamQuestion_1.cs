using System;
using System.Text.RegularExpressions;

namespace oop_assignment_2_2025_78097.Models
{
    public static class ExamQuestion_1
    {

        private static readonly Regex IrishMobileRegex =
            new(@"^(083|085|089)\d{7}$", RegexOptions.Compiled);

        public static void Run()
        {
            Console.WriteLine("Exam Question 1 executed.");

            
            SampleQuestionAMethod();

           
            SampleQuestionBMethod();
        }

        
        public static bool IsValidIrishMobile(string? mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
                return false;

            return IrishMobileRegex.IsMatch(mobileNumber);
        }

        public static void SampleQuestionAMethod()
        {
            Console.WriteLine("Question 1A – Regex demo:");

            var samples = new[]
            {
                "0831234567",
                "0899988776",
                "0812345678",
                "083 1234567",
                "08312345678"
            };

            foreach (var number in samples)
            {
                Console.WriteLine($"{number}: {IsValidIrishMobile(number)}");
            }
        }

        
        public static int GetDiscountPercentage(string? level)
        {
            if (string.IsNullOrWhiteSpace(level))
                return 0;

          
            level = level.Trim();

            
            return level switch
            {
                "Bronze" => 1,
                "Silver" => 5,
                "Gold" => 10,
                "Platinum" => 15,
                "Diamond" => 20,
                "Elite" => 25,
                "VIP" => 30,
                _ => 0
            };
        }

        public static void SampleQuestionBMethod()
        {
            Console.WriteLine("Question 1B – Discount demo:");

            var levels = new[]
            {
                "Bronze", "Silver", "Gold", "Platinum",
                "Diamond", "Elite", "VIP", "Unknown"
            };

            foreach (var level in levels)
            {
                Console.WriteLine($"{level}: {GetDiscountPercentage(level)}%");
            }
        }
    }
}
