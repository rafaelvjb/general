using EF.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Mapping
{
    public class OrderMap: EntityTypeConfiguration<Order>  
    {
        public OrderMap()
        {
            //key  
            HasKey(t => t.ID);

            //fields  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Quantity).IsRequired().HasColumnType("tinyint");
            Property(t => t.Price).IsRequired();
            Property(t => t.CustomerId).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.IP);

            //table  
            ToTable("Orders");

            //relationship
            HasRequired(t => t.Customer).WithMany(c => c.Orders).HasForeignKey(t => t.CustomerId).WillCascadeOnDelete(false);
        }
    }
}
