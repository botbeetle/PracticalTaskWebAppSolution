using System.ComponentModel.DataAnnotations;

namespace PracticalTask.WebApp.Dto.Validations;

public sealed class ValidationBirthDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            if (date.Date > DateTime.Today)
            {
                return new ValidationResult($"The Date {date:d} must be less than Today.");
            }

            if (date.Date < new DateTime(1900, 1, 1))
            {
                return new ValidationResult($"The Date {date:d} must be more than 1900");
            }

            return ValidationResult.Success;

        }
        return new ValidationResult($"The {validationContext.DisplayName} field must be a date.");
    }
}