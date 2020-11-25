using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public int Dni { get; set; }
        public int Cbu { get; set; }
    }
}
