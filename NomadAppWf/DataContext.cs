namespace NomadAppWf
{
    using NomadAppWf.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Getting> Getting { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}