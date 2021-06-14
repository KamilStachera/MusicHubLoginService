using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHubLoginService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHubLoginService.Db
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().ToTable("users");

            //SetupBuilder(modelBuilder.Entity<User>());
        }

        private void SetupBuilder(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.id);
            builder.ToTable("users");
            builder.Property(u => u.id).HasColumnName("id");
            builder.Property(u => u.login).HasColumnName("login");
            builder.Property(u => u.password).HasColumnName("password");
        }
    }
}
