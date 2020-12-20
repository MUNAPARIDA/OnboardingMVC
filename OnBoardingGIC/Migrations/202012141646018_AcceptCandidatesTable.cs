namespace OnBoardingGIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcceptCandidatesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptedCandidates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CandidateId = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AcceptedCandidates");
        }
    }
}
