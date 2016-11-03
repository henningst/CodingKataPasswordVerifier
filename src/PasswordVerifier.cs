using System;

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
            return true;
        }
    }
}