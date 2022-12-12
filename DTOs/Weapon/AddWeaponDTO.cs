using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C__RPG_Backend.DTOs.Weapon
{
    public class AddWeaponDTO
    {
        public string Name { get; set; } = string.Empty;
        public int CharacterId { get; set; }
        public RpgClass Type { get; set; } = RpgClass.Warrior;
    }
}