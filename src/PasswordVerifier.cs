using System;
using System.Linq;

namespace ConsoleApplication 
{
    public class PasswordVerifier
    {
        public bool Verify(string password)
        {
            if(password == null) 
            {
                throw new ArgumentException("The password should not be null");
            }

            if(password.Length <= 8) {
                throw new ArgumentException("The password must be longer than 8 chars");
            }

            if(!ContainsOneUppercaseLetter(password))
            {
                throw new ArgumentException("The password should have at least one uppercase letter"); 
            }

            return true;
        }

        private bool ContainsOneUppercaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }
    }
}