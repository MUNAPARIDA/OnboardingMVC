namespace OnBoardingGIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentsUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "UserID");
        }
    }
}
