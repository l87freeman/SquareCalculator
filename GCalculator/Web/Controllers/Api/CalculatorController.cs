using System.Collections.Generic;
using System.Web.Http;
using Services;
using Services.Interfaces;
using Services.Models;
using Web.Models;
using Web.Utils;

namespace Web.Controllers.Api
{
    public class CalculatorController : ApiController
    {
        private readonly ICalculatorService _calculator;

        public CalculatorController(ICalculatorService calculator)
        {
            _calculator = calculator;
        }
        [HttpPost]
        public IHttpActionResult Calculate([FromBody]List<Point> points)
        {
            var mappedList = AutoMapperBase.Mapper.Map<List<Point>, List<PointDto>>(points);
            var calculationResultDto = _calculator.CalculateSquareAndCheckResult(mappedList);
            //redundant but with good intentions
            var calculationResult = AutoMapperBase.Mapper.Map<CalculationResultDto, CalculationResult> (calculationResultDto);
            return Ok(calculationResult);
        }
    }
}
