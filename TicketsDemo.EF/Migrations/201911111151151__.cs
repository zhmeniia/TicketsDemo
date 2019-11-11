namespace TicketsDemo.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyMargin",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Margin = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Train", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyMargin", "Id", "dbo.Train");
            DropIndex("dbo.CompanyMargin", new[] { "Id" });
            DropTable("dbo.CompanyMargin");
        }
    }
}
