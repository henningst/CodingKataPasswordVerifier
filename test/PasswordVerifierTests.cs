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
            Assert.True(_passwordVerifier.Verify("Mypassword"));
        }

        [Fact]
        public void Verify_WhenPassword8CharsOrShorter_ShouldThrowException() 
        {
            Assert.Throws<ArgumentException>(() => _passwordVerifier.Verify("shortpw"));
        }

        [Fact]
        public void Verify_WhenPassword8CharsOrShorter_ShouldHaveUsefulExceptionMessage() 
        {
            var exception = Assert.Throws<ArgumentException>(() => _passwordVerifier.Verify("shortpw"));
            Assert.Equal("The password must be longer than 8 chars", exception.Message);
        }

        [Fact]
        public void Verify_WhenPasswordIsNull_ShouldThrowExceptionWithUsefulMessage()
        {
            var exception = Assert.Throws<ArgumentException>(() => _passwordVerifier.Verify(null));
            Assert.Equal("The password should not be null", exception.Message);
        }

        [Fact]
        public void Verify_WhenPasswordDoesNotContainAtLeastOneUpperCaseLetter_ShouldThrowExceptionWithUsefulMessage()
        {
            var exception = Assert.Throws<ArgumentException>(() => _passwordVerifier.Verify("passwordwithoutuppercase"));
            Assert.Equal("The password should have at least one uppercase letter", exception.Message);
        } 
    }
}