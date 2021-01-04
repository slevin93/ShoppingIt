using System;

namespace ShoppingIt.Crm.Core.Dto
{
    /// <summary>
    /// Define user access token.
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The bearer token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The token expiry date time.
        /// </summary>
        public DateTime Expiry { get; set; }
    }
}
