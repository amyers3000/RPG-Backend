using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C__RPG_Backend.DTOs.Character
{
    public class GetWeaponDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
    }
}