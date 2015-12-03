namespace LibrarySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBooks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
