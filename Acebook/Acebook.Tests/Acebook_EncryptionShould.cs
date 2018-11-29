using NUnit.Framework;
using Acebook.Models;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ReturnEncryptedString()
        {
            var encrypted = Encryption.EncryptPassword("test");
            Assert.That(encrypted, Is.EqualTo("2s588k/0kB31nKqs2h696g=="));
        }

        [Test]
        public void ReturnDecryptedString()
        {
            var decrypted = Encryption.DecryptPassword("2s588k/0kB31nKqs2h696g==");
            Assert.That(decrypted, Is.EqualTo("test"));
        }
    }
}