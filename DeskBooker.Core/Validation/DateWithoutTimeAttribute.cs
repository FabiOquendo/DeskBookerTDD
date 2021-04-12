using System;
using System.ComponentModel.DataAnnotations;

namespace DeskBooker.Core.Validation
{
    public class DateWithoutTimeAttribute : ValidationAttribute
    {
        public DateWithoutTimeAttribute()
        {
            ErrorMessage = "Date must not contain time";
        }

        public override bool IsValid(object value)
        {
            var isValid = false;

            if (value is DateTime dateTime)
            {
                isValid = dateTime.TimeOfDay.Ticks == 0;
            }

            return isValid;
        }
    }
}
