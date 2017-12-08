namespace JunsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sex = c.String(),
                        Age = c.Int(nullable: false),
                        Class_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .Index(t => t.Class_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
