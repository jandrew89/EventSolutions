using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Repository.Models;

namespace Assignment.Repository.DataModel
{
    public class AssignmentDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Assignment.Repository.Models.Assignment> Assignments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderSummary> OrderSummary { get; set; }
        public DbSet<UserAssignment> UserAssignment { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public AssignmentDbContext() : base("CWF_Assignment")
        {
            Database.SetInitializer<AssignmentDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
