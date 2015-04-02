using TagMyCoins.Domain.Entities;
using TagMyCoins.Infra.Data.Context;

namespace TagMyCoins.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TagMyCoinsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TagMyCoinsContext context)
        {
          //  context.Tags.Add(   );
            //var tag1 = new Tag()
            //{
            //    TagId = Guid.NewGuid(),
            //    UpdatedDate = DateTime.Now,
            //    CreatedDate = DateTime.Now,
            //    Name = "tagname1"
            //};
            //var tag2 = new Tag()
            //{
            //    TagId = Guid.NewGuid(),
            //    UpdatedDate = DateTime.Now,
            //    CreatedDate = DateTime.Now,
            //    Name = "tagname2"
            //};
            //var tag3 = new Tag()
            //{
            //    TagId = Guid.NewGuid(),
            //    UpdatedDate = DateTime.Now,
            //    CreatedDate = DateTime.Now,
            //    Name = "tagname3",
            //    ParentTagId = tag1.TagId
            //};
            //context.Tags.Add(tag1);
            //context.Tags.Add(tag2);
            //context.Tags.Add(tag3);

        }
    }
}
