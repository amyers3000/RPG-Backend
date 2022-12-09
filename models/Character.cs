using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C__RPG_Backend.models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        // one - many relationship
        public User? User { get; set; }
    }
}