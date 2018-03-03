using System;
using System.Collections.Generic;
using System.Linq;
using Services;
using Services.Models;

namespace GCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<PointDto>
            {
                new PointDto {X = 1, Y = 2},
                new PointDto {X = 1, Y = 3},
                new PointDto {X = 1, Y = 4},
            };
            /*{
                new PointDto {X = 3, Y = 4},
                new PointDto {X = 5, Y = 6},
                new PointDto {X = 9, Y = 5},
                new PointDto {X = 12, Y = 8},
                new PointDto {X = 5, Y = 11}
            };*/

            CalculatorService cs = new CalculatorService();
            var result = cs.CalculateSquareAndCheckResult(list);
            foreach (var item in result.Points)
            {
                Console.WriteLine($"{item.X} {item.Y}");
            }
            Console.WriteLine($"{result.Square}");
            Console.WriteLine($"{result.IsValidationPassed}");
            Console.ReadKey();
        }
    }
}
