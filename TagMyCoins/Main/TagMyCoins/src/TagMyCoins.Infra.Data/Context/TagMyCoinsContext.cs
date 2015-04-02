using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Domain.Entities;
using TagMyCoins.Infra.Data.EntityConfig;

namespace TagMyCoins.Infra.Data.Context
{
    public class TagMyCoinsContext : DbContext
    {
        public TagMyCoinsContext()
            : base("TagMyCoins")
        {

        }

        //Tables
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<GeoPosition> GeoPositions { get; set; }
        //public DbSet<Reminder> Reminders { get; set; }
        //public DbSet<Repetition> Repetitions { get; set; }
        //public DbSet<ScanBill> ScanBills { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // ModelConfiguration
            modelBuilder.Configurations.Add(new EntryConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //changetracker verifica todas as alterações. 
            //foreach (var entry in ChangeTracker.Entries())
            //{//.Where(e => e.Entity.GetType().GetProperty("CreatedDate") != null
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("CreatedDate").CurrentValue = DateTime.Now;
            //        //entry.Property("CreatedByUser").CurrentValue = usuarioatual
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("CreatedDate").IsModified = false;
            //        entry.Property("CreatedByUser").IsModified = false;

            //        entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
            //        //entry.Property("UpdatedByUser").CurrentValue = usuarioatual
            //    }
            //}
            
            return base.SaveChanges();
        } 
    }

}
