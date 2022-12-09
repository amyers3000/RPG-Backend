using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// Install Entitly Frameworks CLI globally (done)
// Add from nuget gallery or online (shift command p to get to nuget) Microsoft.EntityFrameworkCore.Design
// Add Microsoft.EntityFrameworkCore.Sqlite
// Add connections string
// Add to services
// dotnet ef -h for help
// create first migration - dotnet ef migrations add IntialCreate
// create table(will run last migration) - dotnet ef database update
// use SQLite extension to see table (shift commantd p) - search SQLite and opiton should show

namespace C__RPG_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        // name of prop is the name of the table; if you want to add more tables you add another DbSet with the generic type of your model
        public DbSet<Character> Characters { get; set; }
    }
}