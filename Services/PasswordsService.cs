using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Services
{
    //Each file is named after the type it declares: PasswordResult is declared in PasswordsService.cs, so it could go in its own file PasswordResult.cs
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

            //The assignment asks passwords with a score below 3 to be rejected: which score should be the limit here? Right now a score of 2 is accepted
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