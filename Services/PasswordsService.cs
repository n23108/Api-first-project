using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Services
{
    public class PasswordResult
    {
        public bool IsValid { get; set; }
        public int Score { get; set; }
        public string Message { get; set; }
    }
    public class PasswordsService : IPasswordsService
    {
        public PasswordResult EvaluatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new PasswordResult
                {
                    IsValid = false,
                    Score = 0,
                    Message = "הסיסמה לא יכולה להיות ריקה"
                };
            }

            var result = Core.EvaluatePassword(password);
            int score = result.Score;

            if (score < 2)
            {
                return new PasswordResult
                {
                    IsValid = false,
                    Score = score,
                    Message = "הסיסמה חלשה מדי"
                };
            }

            return new PasswordResult
            {
                IsValid = true,
                Score = score,
                Message = "הסיסמה חזקה מספיק"
            };
        }
    }
}