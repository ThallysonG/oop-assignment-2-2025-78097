using System;
using System.Collections.Generic;
using System.Globalization;
using oop_assignment_2_2025_78097.Models;
using Xunit;

namespace oop_assignment_2_2025_78097.Tests
{
    
  
  
    public class ExamQuestion1Tests
    {
        [Theory]
        [InlineData("0831234567", true)]
        [InlineData("0851234567", true)]
        [InlineData("0891234567", true)]
        [InlineData("0812345678", false)]   
        [InlineData("083 1234567", false)]  
        [InlineData("08312345678", false)]  
        [InlineData("", false)]
        [InlineData(null, false)]
        public void IsValidIrishMobile_WorksAsExpected(string? number, bool expected)
        {
           
            var result = ExamQuestion_1.IsValidIrishMobile(number);

            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Bronze", 1)]
        [InlineData("Silver", 5)]
        [InlineData("Gold", 10)]
        [InlineData("Platinum", 15)]
        [InlineData("Diamond", 20)]
        [InlineData("Elite", 25)]
        [InlineData("VIP", 30)]
        [InlineData(" Unknown ", 0)]  
        [InlineData("", 0)]
        [InlineData(null, 0)]
        public void GetDiscountPercentage_ReturnsExpected(string? level, int expected)
        {
            var result = ExamQuestion_1.GetDiscountPercentage(level);
            Assert.Equal(expected, result);
        }
    }

   
    public class ExamQuestion2Tests
    {
        [Theory]
        [InlineData(10, 2, "5")]
        [InlineData(9, 3, "3")]
        [InlineData(0, 5, "0")]
        public void Divide_ValidDivisor_ReturnsResult(int dividend, int divisor, string expected)
        {
            var result = ExamQuestion_2.Divide(dividend, divisor);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ByZero_ReturnsErrorMessage()
        {
            var result = ExamQuestion_2.Divide(10, 0);
            Assert.Equal("Cannot divide by 0", result);
        }

        [Theory]
        [InlineData("123", "123")]
        [InlineData("-5", "-5")]
        public void ParseNumber_ValidInput_ReturnsParsedValue(string input, string expected)
        {
            var result = ExamQuestion_2.ParseNumber(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("")]
        public void ParseNumber_InvalidInput_ReturnsErrorMessage(string input)
        {
            var result = ExamQuestion_2.ParseNumber(input);
            Assert.Equal("Invalid number entered.", result);
        }

        [Theory]
        [InlineData(18, "Registration successful.")]
        [InlineData(25, "Registration successful.")]
        public void RegisterUser_Adult_ReturnsSuccess(int age, string expected)
        {
            var result = ExamQuestion_2.RegisterUser(age);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(10)]
        public void RegisterUser_TooYoung_ReturnsErrorMessage(int age)
        {
            var result = ExamQuestion_2.RegisterUser(age);
            Assert.Equal("User must be at least 18 to register.", result);
        }
    }

    
    
    
    public class ExamQuestion3Tests
    {
        [Fact]
        public void CalculateAverageRating_NullOrEmpty_ReturnsNull()
        {
            double? result1 = ExamQuestion_3.CalculateAverageRating(null!);
            double? result2 = ExamQuestion_3.CalculateAverageRating(new List<int>());

            Assert.Null(result1);
            Assert.Null(result2);
        }

        [Fact]
        public void CalculateAverageRating_ValidList_ReturnsAverage()
        {
            var ratings = new List<int> { 5, 4, 3 };
            double? result = ExamQuestion_3.CalculateAverageRating(ratings);

            Assert.NotNull(result);
            Assert.Equal(4.0, result.Value, 5); 
        }

        [Fact]
        public void GetProductSummaries_UsesAverageAndNoRatingsMessage()
        {
            var products = new List<(string Name, List<int> Ratings)>
            {
                ("Laptop", new List<int> { 5, 4, 4, 5, 3 }), 
                ("EmptyProduct", new List<int>())             
            };

            var summaries = ExamQuestion_3.GetProductSummaries(products);

            Assert.Equal(2, summaries.Count);
            Assert.Contains("Laptop: Average Rating = 4.2", summaries);
            Assert.Contains("EmptyProduct: No ratings available", summaries);
        }

        [Fact]
        public void GetProductSummaries_WithSampleProducts_MatchesExpectedStrings()
        {
            var products = ExamQuestion_3.GetSampleProducts();

            var summaries = ExamQuestion_3.GetProductSummaries(products);

            Assert.Contains("Laptop: Average Rating = 4.2", summaries);
            Assert.Contains("Headphones: Average Rating = 4.0", summaries);
            Assert.Contains("Keyboard: Average Rating = 4.8", summaries);
            Assert.Contains("Mouse: Average Rating = 3.3", summaries);
        }

        [Fact]
        public void GetTopRatedProductSummary_WithSampleProducts_ReturnsKeyboard()
        {
            var products = ExamQuestion_3.GetSampleProducts();

            var summary = ExamQuestion_3.GetTopRatedProductSummary(products);

            Assert.Equal(
                "The top-rated product is Keyboard with an average rating of 4.8",
                summary);
        }

        [Fact]
        public void GetTopRatedProductSummary_AllNoRatings_ReturnsNull()
        {
            var products = new List<(string Name, List<int> Ratings)>
            {
                ("A", new List<int>()),
                ("B", new List<int>())
            };

            var result = ExamQuestion_3.GetTopRatedProductSummary(products);

            Assert.Null(result);
        }
    }

    
   
    
    public class ExamQuestion4Tests
    {
        [Theory]
        [InlineData(0, "00000")]
        [InlineData(42, "00042")]
        [InlineData(12345, "12345")]
        [InlineData(999999, "999999")] // more than 5 digits – no truncation
        public void FormatAsFiveDigits_AlwaysFiveDigitsOrMore(int input, string expected)
        {
            var result = ExamQuestion_4.FormatAsFiveDigits(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1234.5, "€1,234.50")]
        [InlineData(0.0, "€0.00")]
        [InlineData(1000000.99, "€1,000,000.99")]
        public void FormatPrice_UsesEuroSymbolAndTwoDecimals(double input, string expected)
        {
            var price = (decimal)input;

            var result = ExamQuestion_4.FormatPrice(price);

            Assert.Equal(expected, result);
        }
    }

}
