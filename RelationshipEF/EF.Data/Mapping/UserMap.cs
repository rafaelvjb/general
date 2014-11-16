using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EF.Core.Data;

namespace EF.Data.Mapping
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //Key
            HasKey(t => t.ID);
            
            //Fields
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //autoincrement option
            Property(t => t.UserName).IsRequired().HasMaxLength(25);
            Property(t => t.Email).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.IP);

            //table
            ToTable("User");
        }
    }
}
