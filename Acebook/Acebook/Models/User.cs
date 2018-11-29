using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Acebook.Models
{
    public class User
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
