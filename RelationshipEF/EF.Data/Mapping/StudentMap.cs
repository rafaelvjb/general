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
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //key  
            HasKey(t => t.ID);

            //property  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name);
            Property(t => t.Age);
            Property(t => t.IsCurrent);
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.IP);

            //table  
            ToTable("StudentMotherFucker");  

            //Relationship
            HasMany(t=> t.Courses)
                .WithMany(s=> s.Students)
                .Map(t=> t.ToTable("StudentCourse")
                    .MapLeftKey("StudentId")
                    .MapRightKey("CourseId"));
        }
    }
}
