using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Defines user account details.
    /// </summary>
    public class Account
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
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets password salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets login attempts.
        /// </summary>
        public int LoginAttempt { get; set; }

        /// <summary>
        /// Gets or sets is account locked.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets unlock date time.
        /// </summary>
        public DateTime? UnlockDateTime { get; set; }

        /// <summary>
        /// Gets or sets time stamp account was created.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<AssignedAccountType> AssignedAccountTypes { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
