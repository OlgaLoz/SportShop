namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bets", "Lot_Id", "dbo.Lots");
            DropIndex("dbo.Bets", new[] { "Lot_Id" });
            RenameColumn(table: "dbo.Bets", name: "Lot_Id", newName: "LotId");
            AlterColumn("dbo.Bets", "LotId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bets", "LotId");
        //    AddForeignKey("dbo.Bets", "LotId", "dbo.Lots", "Id", cascadeDelete: true);
            DropColumn("dbo.Lots", "BetCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lots", "BetCount", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bets", "LotId", "dbo.Lots");
            DropIndex("dbo.Bets", new[] { "LotId" });
            AlterColumn("dbo.Bets", "LotId", c => c.Int());
            RenameColumn(table: "dbo.Bets", name: "LotId", newName: "Lot_Id");
            CreateIndex("dbo.Bets", "Lot_Id");
            AddForeignKey("dbo.Bets", "Lot_Id", "dbo.Lots", "Id");
        }
    }
}
