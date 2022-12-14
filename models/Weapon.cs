namespace C__RPG_Backend.models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }

        public RpgClass Type { get; set; } = RpgClass.Warrior;
    }
}