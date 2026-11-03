using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Services
{
    public class PasswordsService
    {
        public object EvaluatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new
                {
                    isValid = false,
                    score = 0,
                    message = "הסיסמה לא יכולה להיות ריקה"
                };
            }

            var result = Core.EvaluatePassword(password); // Use Core directly
            int score = result.Score;

            if (score < 2)
            {
                return new
                {
                    isValid = false,
                    score = score,
                    message = "הסיסמה חלשה מדי"
                };
            }

            return new
            {
                isValid = true,
                score = score,
                message = "הסיסמה חזקה מספיק"
            };
        }
    }
}