namespace OnBoardingGIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandidateDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidateDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        AddressOne = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Skill = c.String(),
                        Certifications = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CandidateDetails");
        }
    }
}
