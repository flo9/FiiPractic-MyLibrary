namespace MyLibrary.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialBookSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Isbn = c.String(),
                        PubDate = c.DateTime(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
