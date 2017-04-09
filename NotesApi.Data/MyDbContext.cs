using System;
using System.Data.Entity;
using System.IO;

namespace NotesApi.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public MyDbContext()
        {
            this.Database.Connection.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=NotesDB;Trusted_Connection=True;";
            //this.Database.Connection.ConnectionString = File.ReadAllText("_priv/_DATABASE_CONNECTION_STRING.txt");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("Onmodel creati CREATION");
            modelBuilder.Entity<UserEntity>().Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<UserEntity>().HasKey(p => p.Id);

            modelBuilder.Entity<Note>().Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Note>().HasKey(p => p.Id);         
        }     
    }
}