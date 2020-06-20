using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace hci2020_doctors_ui.Validation
{
    public class TimeExpiredRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime selectedTime = (DateTime)value;

            if (selectedTime < DateTime.Now.AddMinutes(-1))
            {
                return new ValidationResult(false, "Please select valid time");
            }

            return new ValidationResult(true, null);
        }
    }
}
