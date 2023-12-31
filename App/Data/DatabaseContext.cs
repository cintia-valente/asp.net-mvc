﻿using App.Data.Map;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<ContactModel> Contacts
        {
            get;
            set;
        }

        public DbSet<UserModel> Users
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
