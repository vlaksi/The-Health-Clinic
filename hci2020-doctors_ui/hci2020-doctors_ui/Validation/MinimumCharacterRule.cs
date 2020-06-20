using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace hci2020_doctors_ui.Validation
{
    public class MinimumCharacterRule : ValidationRule
    {

        public int MinimumCharacters { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            
            if(charString.Length < MinimumCharacters)
            {
                return new ValidationResult(false, $"Field must have at least {MinimumCharacters} characters.");
            }

            return new ValidationResult(true, null);
        }
    }
}
