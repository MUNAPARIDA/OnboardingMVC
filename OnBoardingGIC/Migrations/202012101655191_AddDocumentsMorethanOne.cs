namespace OnBoardingGIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentsMorethanOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "twelveStandard", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "twelveStandard");
        }
    }
}
