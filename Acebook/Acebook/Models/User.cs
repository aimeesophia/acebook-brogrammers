using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Acebook.Models;
using Acebook.Controllers;

namespace Acebook.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public static bool AuthenticateSignIn(string password, string enteredpassword)
        {
            var decrypted = Acebook.Models.Encryption.DecryptPassword(password);
            return enteredpassword == decrypted;
        }
    }
}
