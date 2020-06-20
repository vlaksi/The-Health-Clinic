using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace hci2020_doctors_ui.Validation
{
    public class EmailValidationRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (!charString.Contains("@") || !charString.Contains(".") || string.IsNullOrWhiteSpace(charString))
            {
                return new ValidationResult(false, $"Please type a valid email address.");
            }

            return new ValidationResult(true, null); 
        }
    }
}
