using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace AumentaTest.Ejercicio3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppServerDbContext")
        {
            /*Database.SetInitializer
            (
                new DropCreateDatabaseIfModelChanges<AppDbContext>()
            );*/
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new {x.RoleId, x.UserId});
            modelBuilder.Entity<RolePermission>().HasKey(x => new {x.PermissionId, x.RoleId});
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<RolePermission> RolePermission { get; set; }
    }
}
