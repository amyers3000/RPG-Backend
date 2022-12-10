using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__RPG_Backend.DTOs.Skill;
using C__RPG_Backend.DTOs.Weapon;
//there is some information in models not needed by the user so that the model can be mapped to a DTO,
// allowing the user to see only what is pertinent to them; flexibility in what you want to return to clients,
// meaning you can combine properties of different classes.
// The client can also send certain information to a web service, this service then maps it to the actual model
namespace C__RPG_Backend.DTOs.Character
{
    public class GetCharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public GetWeaponDTO Weapon { get; set; }
        public List<GetSkillDTO> Skills { get; set; }
    }
}