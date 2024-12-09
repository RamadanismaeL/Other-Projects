using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace controleDeContactos.ram
{
    /*
    *@author Ramadan ismaeL
    */
    public static class Cryptographic
    {
        private const int _workFactor = 12;

        public static string CreateHash(this string value)
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value), "The Password isn't null or empty. Please try again!");
            try
            {
                return BCrypt.Net.BCrypt.HashPassword(value, workFactor: _workFactor);
            }
            catch (Exception error)
            {
                throw new InvalidOperationException("An error occurred while generating the password, please try again.", error);
            }
        }
    }
}