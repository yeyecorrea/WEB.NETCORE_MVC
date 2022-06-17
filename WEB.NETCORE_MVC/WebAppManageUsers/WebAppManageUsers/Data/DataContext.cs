﻿using Microsoft.EntityFrameworkCore;
using WebAppManageUsers.Data.Entities;

namespace WebAppManageUsers.Data
{
    /// <summary>
    /// Una de las clases más importante y es el DbContext
    /// el DbContex es la clase de c# que representa esa sesión con la base de datos el DbContex es la clase de EF 
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Entidad mapeada, por lo general el nombre es prural "Countires"
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }

        // 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
        }

    }
}
