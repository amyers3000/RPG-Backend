using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// made this DTO because may want to modify UserRegisterDTO in the future for more info; not sure yet
namespace C__RPG_Backend.DTOs.User
{
    public class UserLoginDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}