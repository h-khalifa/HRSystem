using System.ComponentModel.DataAnnotations;

namespace HR_Employes.Models.Validators
{
    public class AttendanceDateValidationAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
        "Attendance Date can only be for today or any day of last 2 weeks!";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var date = ((DateTime)value);
            DateTime maxDate = DateTime.Now.Date;
            DateTime minDate = maxDate.AddDays(-14);

            if ( date <= maxDate && date >= minDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(GetErrorMessage());
        }
    }
}
