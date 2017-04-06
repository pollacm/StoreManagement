using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StoreManagement.Repository.Stores;

namespace StoreManagement.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
