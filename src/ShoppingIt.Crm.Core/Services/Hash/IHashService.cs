
namespace ShoppingIt.Crm.Core.Services.Hash
{
    /// <summary>
    /// Defines interfaces for hashing service.
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Creates a unique salt.
        /// </summary>
        /// <returns>Returns newly created salt as base64 encoding.</returns>
        string GenerateSalt();

        /// <summary>
        /// Hash string using salt.
        /// </summary>
        /// <param name="str">The string to hash.</param>
        /// <param name="salt">The salt to use with the hash.</param>
        /// <returns>Returns newly created hash from <see cref="str"/> and <see cref="salt"/>.</returns>
        string Hash(string str, string salt);

        /// <summary>
        /// Checks if hash 1 is equal to hash 2.
        /// </summary>
        /// <param name="hash1">The first hash.</param>
        /// <param name="hash2">The second hash.</param>
        /// <returns>Returns true if both hashes are equal in value, false if not.</returns>
        bool IsValid(string hash1, string hash2);
    }
}