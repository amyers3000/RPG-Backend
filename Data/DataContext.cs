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
                new Skill { Id = 1, Name = "Fireball", Damage = 30},
                new Skill { Id = 2, Name = "Frenzy", Damage = 20},
                new Skill { Id = 3, Name = "Blizzard", Damage = 15},
                new Skill { Id = 4, Name = "Thunder", Damage = 10},
                new Skill { Id = 5, Name = "Side-Swipe", Damage = 5},
                new Skill { Id = 6, Name = "Slasher", Damage = 40}
            );
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        

    }
}