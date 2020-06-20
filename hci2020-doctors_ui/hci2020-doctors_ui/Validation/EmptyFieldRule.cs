using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace hci2020_doctors_ui.Validation
{
    public class EmptyFieldRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (string.IsNullOrWhiteSpace(charString) || string.IsNullOrEmpty(charString))
            {
                return new ValidationResult(false, "Field cannot be empty!");
            }

            return new ValidationResult(true, null);
        }
    }
}
