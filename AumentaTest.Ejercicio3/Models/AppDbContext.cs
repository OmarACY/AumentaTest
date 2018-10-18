using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AumentaTest.Ejercicio3.Models
{
    public class AppDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AppDbContext() : base("name=AppServerDbContext")
        {
            Database.SetInitializer
            (
                new DropCreateDatabaseIfModelChanges<AppDbContext>()
            );
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
