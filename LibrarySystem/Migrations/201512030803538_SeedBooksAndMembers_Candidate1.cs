namespace LibrarySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBooksAndMembers_Candidate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(nullable: false, maxLength: 20),
                        Title = c.String(nullable: false, maxLength: 100),
                        Keywords = c.String(nullable: false),
                        PublishedYear = c.DateTime(nullable: false),
                        Author = c.String(nullable: false, maxLength: 100),
                        Availability = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 80),
                        Status = c.Int(nullable: false),
                        OutstandingPenalty = c.Double(nullable: false),
                        BorrowedBooksCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        BorrowerId = c.String(),
                        BorrowableId = c.Int(nullable: false),
                        TransactionDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Borrowabe_Id = c.Int(),
                        Borrower_MemberId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Books", t => t.Borrowabe_Id)
                .ForeignKey("dbo.Members", t => t.Borrower_MemberId)
                .Index(t => t.Borrowabe_Id)
                .Index(t => t.Borrower_MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Borrower_MemberId", "dbo.Members");
            DropForeignKey("dbo.Transactions", "Borrowabe_Id", "dbo.Books");
            DropIndex("dbo.Transactions", new[] { "Borrower_MemberId" });
            DropIndex("dbo.Transactions", new[] { "Borrowabe_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Members");
            DropTable("dbo.Books");
        }
    }
}
