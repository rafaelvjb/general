namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testeAddPropertie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "OnLine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "OnLine");
        }
    }
}
