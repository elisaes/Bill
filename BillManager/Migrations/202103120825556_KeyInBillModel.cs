namespace BillManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyInBillModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillModels",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        BillName = c.String(),
                        BillCompany = c.String(),
                        BillPrice = c.Int(nullable: false),
                        BillDueDate = c.DateTime(nullable: false),
                        BillStatus = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BillModels", new[] { "User_Id" });
            DropTable("dbo.BillModels");
        }
    }
}
