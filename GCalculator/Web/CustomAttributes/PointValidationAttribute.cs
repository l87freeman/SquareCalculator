using System.ComponentModel.DataAnnotations;
using Web.Models;


namespace Web.CustomAttributes
{
    public class PointValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var val = value as Point;
            var isValid = true;
            if (val == null)
            {
                this.ErrorMessage = "Null point is not allowed";
                isValid = false;
            }
            
            else if (val.X < 0 || val.Y < 0)
            {
                this.ErrorMessage = $"Value of the point coordinayes cannot be less than 0";
                isValid = false;
            }

            return isValid;
        }
    }
}