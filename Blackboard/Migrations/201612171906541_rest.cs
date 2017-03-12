namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            AddColumn("dbo.Comments", "annnounceID", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Comments", "annnounceID");
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
