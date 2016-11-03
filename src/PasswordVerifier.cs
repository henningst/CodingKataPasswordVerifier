using System;

namespace ConsoleApplication 
{
    public class PasswordVerifier
    {
        public bool Verify(string password)
        {
            if(password.Length <= 8) {
                throw new ArgumentException();
            }
            return true;
        }
    }
}