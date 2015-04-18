namespace MyLibrary.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LendingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lendings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LendingDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Book_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.Book_ID)
                .Index(t => t.Book_ID);
            
            AddColumn("dbo.Books", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "AvailableCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lendings", "Book_ID", "dbo.Books");
            DropIndex("dbo.Lendings", new[] { "Book_ID" });
            DropColumn("dbo.Books", "AvailableCount");
            DropColumn("dbo.Books", "Count");
            DropTable("dbo.Lendings");
        }
    }
}
