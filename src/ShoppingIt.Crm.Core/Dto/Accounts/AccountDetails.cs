using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Dto.Accounts
{
    /// <summary>
    /// Define account details without credentials.
    /// </summary>
    public class AccountDetails
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
