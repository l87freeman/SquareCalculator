using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Services.Models;
using Services.Extentions;
using Services.Interfaces;

namespace Services
{
    public class CalculatorService : ICalculatorService
    {
        /// <summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// </summary>
        /// <param name="points"></param>
        /// <returns>CalculationResultDto object</returns>
        public CalculationResultDto CalculateSquareAndCheckResult(List<PointDto> points)
        {
            var sortedPoints = points.SortByDistance();
            var square = sortedPoints.Select((p, i) =>
            {
                if (p == null)
                    throw new ArgumentNullException($"collection with null element at {i} index");
                var leftOper = (i == 0) ? sortedPoints[sortedPoints.Count - 1].X : sortedPoints[i - 1].X;
                var rightOper = (i == sortedPoints.Count - 1) ? sortedPoints[0].X : sortedPoints[i + 1].X;
                // Debug.WriteLine($"{leftOper} {rightOper}");
                return p.Y * (leftOper - rightOper);
            }).Sum() * 0.5;

            return new CalculationResultDto
            {
                Square = Math.Abs(square),
                IsValidationPassed = CalculationCheck(sortedPoints, square),
                Points = sortedPoints
            };
        }

        private bool CalculationCheck(List<PointDto> points, double square)
        {

            var squareCheck = points.Select((p, i) =>
            {
                var leftOper = (i == points.Count - 1) ? points[0].Y : points[i + 1].Y;
                var rightOper = (i == 0) ? points[points.Count - 1].Y : points[i - 1].Y;
                return p.X * (leftOper - rightOper);
            }).Sum() * 0.5;
            return square.Equals(squareCheck);
        }
    }
}
