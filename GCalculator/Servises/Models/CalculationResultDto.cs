using System.Collections.Generic;

namespace Services.Models
{
    public class CalculationResultDto
    {
        public double Square { get; set; }
        public bool IsValidationPassed { get; set; }
        public List<PointDto> Points { get; set; }
    }
}
