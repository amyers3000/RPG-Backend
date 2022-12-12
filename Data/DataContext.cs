using Microsoft.EntityFrameworkCore;


namespace C__RPG_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        //Seeding Skills
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Fireball", Damage = 30, Type = RpgClass.Mage},
                new Skill { Id = 2, Name = "Frenzy", Damage = 32, Type = RpgClass.Mage},
                new Skill { Id = 3, Name = "Blizzard", Damage = 28, Type = RpgClass.Mage},
                new Skill { Id = 4, Name = "Thunder", Damage = 30, Type = RpgClass.Mage},
                new Skill { Id = 5, Name = "Side-Swipe", Damage = 20, Type = RpgClass.Warrior},
                new Skill { Id = 6, Name = "Slasher", Damage = 18, Type = RpgClass.Warrior},
                new Skill { Id = 7, Name = "Precision Shot", Damage = 30, Type = RpgClass.Archer}

            );
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        

    }
}