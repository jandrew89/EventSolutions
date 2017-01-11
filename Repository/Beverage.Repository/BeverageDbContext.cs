using Beverage.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage.Repository
{
    public class BeverageDbContext : DbContext
    {
        public DbSet<Beverages> Beverages { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Tea> Teas { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DynamicProperty> DynamicCarRecordProperties { get; set; }



        public BeverageDbContext()
             : base("CWF_Customers")
        {
            //Database.SetInitializer(new BeverageDbInitializer());
            Database.SetInitializer<BeverageDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ensure the same person can be added to different collections
            // of friends (self-referencing many-to-many relationship)
             modelBuilder.Entity<Customer>().HasMany(m => m.CoWorkers).WithMany();

             modelBuilder.Entity<Customer>().HasMany(p => p.Cars)
                .WithRequired(r => r.Customer).WillCascadeOnDelete(true);
        }

        public override int SaveChanges()
        {
            var modifiedOrAddedCarRecords = ChangeTracker.Entries<Car>()
                .Where(e => e.State == EntityState.Added
                || e.State == EntityState.Modified
                || e.State == EntityState.Unchanged).ToList();

            for (int i = 0; i < modifiedOrAddedCarRecords.Count; i++)
            {
                var carRecords = modifiedOrAddedCarRecords[i];

                var dynamicProperties = new List<DynamicProperty>();
                foreach (var dynamicPropertyKeyValue in carRecords.Entity.Properties)
                {
                    dynamicProperties.Add(new DynamicProperty()
                    {
                        Key = dynamicPropertyKeyValue.Key,
                        Value = dynamicPropertyKeyValue.Value
                    });
                }

                carRecords.Entity.DynamicCarProperties.Clear();
                foreach (var dynamicPropertyToSave in dynamicProperties)
                {
                    var existingDynamicProperty = ChangeTracker.Entries<DynamicProperty>().FirstOrDefault(d => d.Entity.Key == dynamicPropertyToSave.Key);

                    if(existingDynamicProperty != null)
                    {
                        DynamicCarRecordProperties.Remove(existingDynamicProperty.Entity);
                    }

                    carRecords.Entity.DynamicCarProperties.Add(dynamicPropertyToSave);
                }
            }
            return base.SaveChanges();
        }

    }
}
