using System;

namespace TestDemo
{
    public class LogonInfo
    {
        private string _userId;

        public string UserId
        {
            get { return _userId; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Parameter userId may not be null or blank.");
                }
                _userId = value;
            }
        }

        public string Password { get; set; }

        public LogonInfo(string userId, string password)
        {
            this.UserId = userId;
            this.Password = password;
        }

        /// <summary>
        /// Update the password of the log on user
        /// </summary>
        /// <param name="newPassword"></param>
        public void UpdatePassword(string newPassword)
        {
            this.Password = newPassword;
        }
    }
}
