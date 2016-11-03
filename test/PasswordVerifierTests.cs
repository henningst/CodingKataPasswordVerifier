using Xunit;
using ConsoleApplication;
using System;

namespace Tests
{
    public class PasswordVerifiertests 
    {
        [Fact]
        public void Verify_WhenPasswordLongerThan8Chars_ShouldReturnTrue() {
            var passwordVerifier = new PasswordVerifier();
            Assert.True(passwordVerifier.Verify("mypassword"));
        }

        [Fact]
        public void Verify_WhenPassword8CharsOrShorter_ShouldThrowException() 
        {
            var passwordVerifier = new PasswordVerifier();
            Assert.Throws<ArgumentException>(() => passwordVerifier.Verify("shortpw"));
        }
    }
}