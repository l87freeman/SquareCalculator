using System.Collections.Generic;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICalculatorService
    {
        CalculationResultDto CalculateSquareAndCheckResult(List<PointDto> points);
    }
}
