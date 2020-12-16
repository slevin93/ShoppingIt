using NUnit.Framework;
using ShoppingIt.Crm.Core.Services.Hash;
using System;

namespace ShoppingIt.Crm.Tests
{
    [TestFixture]
    public class HashServiceTest
    {
        private IHashService hashService;

        [SetUp]
        public void SetUp()
        {
            hashService = new HashService();
        }

        [Test]
        public void Hash_GenerateSalt_ReturnsValidSalt()
        {
            var result = hashService.GenerateSalt();

            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("Password@246")]
        [TestCase(":{~:!!(*^&)*(^&£$£")]
        [TestCase("74657;'[[:{~:}{@`¬!")]
        public void Hash_HashString_ReturnsHashedString(string password)
        {
            var salt = hashService.GenerateSalt();

            var hash = hashService.Hash(password, salt);

            Assert.IsNotNull(hash);
        }

        [Test]
        [TestCase(":{~:!!(*^&)*(^&£$£", "WLjYRz0KR40ufn4RwbU+Bw==", ExpectedResult = "HiWmrytVcKCjKvZoPzfyO12no/kJA+UoVw42DGDppQ0=")]
        [TestCase("74657;'[[:{~:}{@`¬!", "K2ay+mz5pZCEqBZUz/OVWg ==", ExpectedResult = "PhnQkdwVq4mczrF2aKRcWZrFDcJgwnlnhTTyDiHOacc=")]
        public string Hash_HashString_ReturnsHashString(string password, string salt)
        {
            return hashService.Hash(password, salt);
        }

        [Test]
        [TestCase(":{~:!!(*^&)*(^&£$£", "WLjYRz0KR40ufn4RwbU+Bw==", "HiWmrytVcKCjKvZoPzfyO12no/kJA+UoVw42DGDppQ0=", ExpectedResult = true)]
        [TestCase("74657;'[[:{~:}{@`¬!", "K2ay+mz5pZCEqBZUz/OVWg ==", "PhnQkdwVq4mczrF2aKRcWZrFDcJgwnlnhTTyDiHOacc=", ExpectedResult = true)]
        public bool Hash_IsValid_ReturnsTrue(string password, string salt, string passwordHash)
        {
            return hashService.IsValid(passwordHash, hashService.Hash(password, salt));
        }

        [Test]
        [TestCase(":{~:!!(*^&)*(^&£$£", "WLjYRz0KR40ufn4RwbU+Bw==", "HiWmrytVcKCjKvZO12no/kJA+UoVw42DGDppQ0=", ExpectedResult = false)]
        [TestCase("74657;'[[:{~:}{@`¬!", "K2ay+mz5pZCEqBZUz/OVWg ==", "PhnQkdwVq4mczrF2cWZrFDcJgwnlnhTTyDiHOacc=", ExpectedResult = false)]
        public bool Hash_IsNotValid_ReturnsFalse(string password, string salt, string passwordHash)
        {
            return hashService.IsValid(passwordHash, hashService.Hash(password, salt));
        }
    }
}
