using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace hci2020_doctors_ui.Validation
{
    public class DateExpiredRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime selectedDate = (DateTime)value;

            if (selectedDate < DateTime.Now)
            {
                return new ValidationResult(false, "Please select a valid date.");
            }

            return new ValidationResult(true, null);
        }
    }
}
