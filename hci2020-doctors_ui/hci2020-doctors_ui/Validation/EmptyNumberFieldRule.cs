using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace hci2020_doctors_ui.Validation
{
    public class EmptyNumberFieldRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int numeric = Convert.ToInt32(value);

            if (numeric == default || numeric == 0)
            {
                return new ValidationResult(false, "Number field cannot be empty!");
            }

            return new ValidationResult(true, null);
        }
    }
}
