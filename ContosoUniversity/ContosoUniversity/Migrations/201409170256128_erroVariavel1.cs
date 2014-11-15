namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erroVariavel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Course_CourseID", c => c.Int());
            CreateIndex("dbo.Course", "Course_CourseID");
            AddForeignKey("dbo.Course", "Course_CourseID", "dbo.Course", "CourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.Course", new[] { "Course_CourseID" });
            DropColumn("dbo.Course", "Course_CourseID");
        }
    }
}
