// <copyright file="HashService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Hash
{
    using System;
    using System.Security.Cryptography;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;

    /// <summary>
    /// Implementation of <see cref="IHashService"/>.
    /// </summary>
    public class HashService : IHashService
    {
        /// <inheritdoc/>
        public string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        /// <inheritdoc/>
        public string Hash(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        /// <inheritdoc/>
        public bool IsValid(string hash1, string hash2)
        {
            return hash1 == hash2;
        }
    }
}