namespace C__RPG_Backend.DTOs.Weapon
{
    public class AddWeaponDTO
    {
        public string Name { get; set; } = string.Empty;
        public int CharacterId { get; set; }
        public RpgClass Type { get; set; } = RpgClass.Warrior;
    }
}