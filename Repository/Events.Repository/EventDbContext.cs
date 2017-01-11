using Events.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Events.Repository
{
    public class EventDbContext : DbContext
    {

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public EventDbContext() : base("CWF_Events")
        {
            Database.SetInitializer<EventDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Events)
                .WithMany()
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Profile>()
            //    .HasMany(u => u.Followees)
            //    .WithRequired(f => f.Follower)
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Profile>()

            //    .HasMany(u => u.Followers)
            //    .WithRequired(f => f.Followee)
            //    .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }

   
}
