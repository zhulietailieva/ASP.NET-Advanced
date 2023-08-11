namespace TrailVenturesSystem.Common
{
    using System.ComponentModel.DataAnnotations;

    public class ValidateBeforeTodayAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue.Date >= DateTime.Today;
            }

            return false;
        }
    }
}
