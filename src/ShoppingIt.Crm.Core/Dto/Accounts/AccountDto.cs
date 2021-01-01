using System;

namespace ShoppingIt.Crm.Core.Dto.Accounts
{
    /// <summary>
    /// Defines the account details to return from data access.
    /// </summary>
    public class AccountAuthDto
    {
        /// <summary>
        /// Gets or sets account id.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets the login attempt.
        /// </summary>
        public int LoginAttempt { get; set; }

        /// <summary>
        /// Gets or sets if the account is locked.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the unlock date time.
        /// </summary>
        public DateTime? UnlockDataTime { get; set; }
    }
}
