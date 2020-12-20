namespace OnBoardingGIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocuments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        documentId = c.Int(nullable: false, identity: true),
                        tenStandard = c.Binary(),
                    })
                .PrimaryKey(t => t.documentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
