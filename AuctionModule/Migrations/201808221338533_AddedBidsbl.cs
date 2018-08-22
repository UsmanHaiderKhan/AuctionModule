namespace AuctionModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBidsbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuctionId = c.Long(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .Index(t => t.AuctionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "AuctionId" });
            DropTable("dbo.Bids");
        }
    }
}
