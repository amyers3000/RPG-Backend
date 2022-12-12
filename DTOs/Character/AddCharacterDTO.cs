namespace C__RPG_Backend.DTOs.Character
{
    public class AddCharacterDTO
    {
        public string Name { get; set; } = "Donald";
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Mage;
    }
}