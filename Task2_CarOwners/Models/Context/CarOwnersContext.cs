using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Task2_CarOwners.Models.Context
{
    public class CarOwnersContext : DbContext
    {
        static CarOwnersContext()
        {
            Database.SetInitializer(new CarOwnersContextInitializer());
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}