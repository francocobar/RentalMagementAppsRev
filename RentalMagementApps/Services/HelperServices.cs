using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementApps.Services
{
    public class HelperServices
    {
        public string hash(string txtInput)
        {
            string hash = "";
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var varhashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(txtInput));
                // Get the hashed string.  
                hash = BitConverter.ToString(varhashedBytes).Replace("-", "").ToLower();
                // Print the string.   
            }
            return hash;
        }
    }
}
