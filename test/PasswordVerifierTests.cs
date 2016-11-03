using Xunit;
using ConsoleApplication;
using System;

namespace Tests
{
    public class PasswordVerifierTests
    {
        private PasswordVerifier _passwordVerifier;

        public PasswordVerifierTests()
        {
            _passwordVerifier = new PasswordVerifier();
        }

        [Fact]
        public void Verify_WhenPasswordLongerThan8Chars_ShouldReturnTrue() {
            Assert.True(_passwordVerifier.Verify("mypassword"));
        }

        [Fact]
        public void Verify_WhenPassword8CharsOrShorter_ShouldThrowException() 
        {
            Assert.Throws<ArgumentException>(() => _passwordVerifier.Verify("shortpw"));
        }
    }
}