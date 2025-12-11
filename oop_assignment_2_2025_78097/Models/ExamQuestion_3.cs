using System;
using System.Collections.Generic;
using System.Linq;

namespace oop_assignment_2_2025_78097.Models
{
    public static class ExamQuestion_3
    {
        public static void Run()
        {
            Console.WriteLine("Exam Question 3 executed.");

            var products = GetSampleProducts();

           
            var summaries = GetProductSummaries(products);
            foreach (var line in summaries)
            {
                Console.WriteLine(line);
            }

            
            var topSummary = GetTopRatedProductSummary(products);
            if (!string.IsNullOrEmpty(topSummary))
            {
                Console.WriteLine(topSummary);
            }
        }

        public static List<(string Name, List<int> Ratings)> GetSampleProducts()
        {
            return new List<(string Name, List<int> Ratings)>
            {
                ("Laptop",     new List<int> { 5, 4, 4, 5, 3 }),
                ("Headphones", new List<int> { 4, 3, 5 }),
                ("Keyboard",   new List<int> { 5, 5, 5, 4 }),
                ("Mouse",      new List<int> { 3, 3, 4 })
            };
        }

       
        public static double? CalculateAverageRating(List<int> ratings)
        {
            if (ratings == null || ratings.Count == 0)
                return null;

            return ratings.Average();
        }

        
        public static List<string> GetProductSummaries(
            List<(string Name, List<int> Ratings)> products)
        {
            var result = new List<string>();

            foreach (var product in products)
            {
                var avg = CalculateAverageRating(product.Ratings);

                if (avg.HasValue)
                {
                    string formatted = avg.Value.ToString("0.0");
                    result.Add($"{product.Name}: Average Rating = {formatted}");
                }
                else
                {
                    result.Add($"{product.Name}: No ratings available");
                }
            }

            return result;
        }

       
        public static string? GetTopRatedProductSummary(
            List<(string Name, List<int> Ratings)> products)
        {
            string? bestName = null;
            double bestAverage = double.MinValue;

            foreach (var product in products)
            {
                var avg = CalculateAverageRating(product.Ratings);
                if (!avg.HasValue)
                    continue;

                if (avg.Value > bestAverage)
                {
                    bestAverage = avg.Value;
                    bestName = product.Name;
                }
            }

            if (bestName == null)
                return null;

            string formattedAverage = bestAverage.ToString("0.0");
            return $"The top-rated product is {bestName} with an average rating of {formattedAverage}";
        }
    }
}
