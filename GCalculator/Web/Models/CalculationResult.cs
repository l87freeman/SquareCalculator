using System.Collections.Generic;

namespace Web.Models
{
    public class CalculationResult
    {
        public double Square { get; set; }
        public bool IsValidationPassed { get; set; }
        public List<Point> Points { get; set; }
    }
}