using System.ComponentModel.DataAnnotations;

namespace ShopApi23.Attributes
{
    public class PositiveNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (double)value >= 0;
        }
    }
}