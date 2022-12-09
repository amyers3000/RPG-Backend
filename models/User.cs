using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C__RPG_Backend.models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //many to one relationship
        public List<Character>? Characters { get; set; }

    }
}