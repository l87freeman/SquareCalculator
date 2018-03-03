using System;

namespace Services.Models
{
    public class PointDto// : IComparable<PointDto>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointDto()
        {
        }

        public PointDto(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
