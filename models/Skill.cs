namespace C__RPG_Backend.models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public RpgClass Type { get; set; }
        public List<Character> Characters { get; set; }
    }
}