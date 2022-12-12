using System.Text.Json.Serialization;

namespace C__RPG_Backend.models
{
    // Without JSON Converter only array or values show up
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Warrior = 1,
        Mage = 2,
        Archer = 3,
        
    }
}