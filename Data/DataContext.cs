using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__RPG_Backend.models;
using Microsoft.EntityFrameworkCore;

// Install Entitly Frameworks CLI globally (done)
// Add from nuget gallery or online (shift command p to get to nuget) Microsoft.EntityFrameworkCore.Design
// Add Microsoft.EntityFrameworkCore.Sqlite
// Add connections string
// Add to services
// dotnet ef -h for help
// create first migration - dotnet ef migrations add IntialCreate(whatever you want to name migration)
// create table(will run last migration) - dotnet ef database update
// use SQLite extension to see table (shift commantd p) - search SQLite and opiton should show

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

        // name of prop is the name of the table; if you want to add more tables you add another DbSet with the generic type of your model
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        

    }
}