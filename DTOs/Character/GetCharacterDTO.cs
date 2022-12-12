using C__RPG_Backend.DTOs.Skill;

namespace C__RPG_Backend.DTOs.Character
{
    public class GetCharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Donald";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Mage;
        public GetWeaponDTO Weapon { get; set; }
        public List<GetSkillDTO> Skills { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}