namespace AumentaTest.Ejercicio3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AumentaTest.Ejercicio3.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AumentaTest.Ejercicio3.Models.AppDbContext";
        }
    }
}
