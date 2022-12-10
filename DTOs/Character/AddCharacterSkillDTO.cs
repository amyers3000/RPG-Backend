using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C__RPG_Backend.DTOs.Character
{
    public class AddCharacterSkillDTO
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
    }
}