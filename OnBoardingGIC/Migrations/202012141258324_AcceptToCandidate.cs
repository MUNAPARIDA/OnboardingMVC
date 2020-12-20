namespace OnBoardingGIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcceptToCandidate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Accepted");
        }
    }
}
