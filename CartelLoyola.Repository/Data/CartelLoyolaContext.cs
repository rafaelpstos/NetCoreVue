using System;
using CartelLoyola.Repository;
using System.Collections.Generic;
using System.Text;
using CartelLoyola.Domain;
using Microsoft.EntityFrameworkCore;

namespace CartelLoyola.Data
{
    public partial class CartelLoyolaContext : DbContext
    {

        public CartelLoyolaContext() 
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Imagem> Images { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-AOFM6LE\SQLEXPRESS;Database=CartelLoyolaDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Imagem>().ToTable("Images");
            modelBuilder.Entity<Login>().ToTable("Login");
        }
    }
}
