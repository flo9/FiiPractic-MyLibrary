namespace MyLibrary.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LendingChangeUserColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lendings", "UserName", c => c.String());
            DropColumn("dbo.Lendings", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lendings", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Lendings", "UserName");
        }
    }
}
