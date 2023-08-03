namespace TrailVenturesSystem.Common
{
    using System.ComponentModel.DataAnnotations;

    public class ValidateBeforeTodayAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            if (value is DateTime dateValue)
            {
                // Compare the provided date with today's date.
                return dateValue.Date >= DateTime.Today;
            }

            // If the value is not a DateTime, the validation fails.
            return false;
        }
    }
}
