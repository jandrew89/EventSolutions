using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace User.Repository.Entities
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("Data Source=basil.arvixe.com;Initial Catalog=CWF_Users;Integrated Security=false;User ID=inet_admin;Password=_Pass4369")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()
                .HasRequired(ui => ui.User);
                
            base.OnModelCreating(modelBuilder);
        }
    }

    public class UserInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {

            base.Seed(context);
        }
    }
}