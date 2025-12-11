using System;

namespace oop_assignment_2_2025_78097.Models
{
    public static class ExamQuestion_2
    {
        public static void Run()
        {
            Console.WriteLine("Exam Question 2 executed.");

            Console.WriteLine("2A: Divide(10, 0) => " + Divide(10, 0));
            Console.WriteLine("2B: ParseNumber(\"123\") => " + ParseNumber("123"));
            Console.WriteLine("2B: ParseNumber(\"abc\") => " + ParseNumber("abc"));
            Console.WriteLine("2C: RegisterUser(25) => " + RegisterUser(25));
            Console.WriteLine("2C: RegisterUser(15) => " + RegisterUser(15));
        }

        
        public static string Divide(int dividend, int divisor)
        {
            try
            {
                int result = dividend / divisor;
                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return "Cannot divide by 0";
            }
        }

       
        public static string ParseNumber(string input)
        {
            try
            {
                int value = int.Parse(input);
                return value.ToString();
            }
            catch (Exception)
            {
                return "Invalid number entered.";
            }
        }

       
        public static string RegisterUser(int age)
        {
            try
            {
                if (age < 18)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(age),
                        "User must be at least 18 to register.");
                }

                return "Registration successful.";
            }
            catch (ArgumentOutOfRangeException)
            {
                return "User must be at least 18 to register.";
            }
        }
    }
}
