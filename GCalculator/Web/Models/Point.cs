using System;
using Web.CustomAttributes;

namespace Web.Models
{
    //[PointValidation]
    public class Point
    {
        private double _x, _y;
        public double X
        {
            get => _x;
            set
            {
                if (value < 0)
                    throw new ArgumentException("value of x cannot be less than 0");

                _x = value;
            }
        }
        public double Y
        {
            get => _y;
            set
            {
                if (value < 0)
                    throw new ArgumentException("value of y cannot be less than 0");

                _y = value;
            }
        }
    }
}