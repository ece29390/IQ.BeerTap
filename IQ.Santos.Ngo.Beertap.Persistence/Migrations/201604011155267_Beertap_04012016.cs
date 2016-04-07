namespace IQ.Santos.Ngo.Beertap.Persistence
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Beertap_04012016 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keg",
                c => new
                    {
                        KegId = c.Int(nullable: false, identity: true),
                        BeerBrand = c.String(maxLength: 50),
                        VolumeLeft = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.KegId);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Tap",
                c => new
                    {
                        TapId = c.Int(nullable: false, identity: true),
                        OfficeName = c.String(maxLength: 50),
                        KegId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TapId)
                .ForeignKey("dbo.Keg", t => t.KegId, cascadeDelete: true)
                .ForeignKey("dbo.Office", t => t.OfficeName)
                .Index(t => t.OfficeName)
                .Index(t => t.KegId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tap", "OfficeName", "dbo.Office");
            DropForeignKey("dbo.Tap", "KegId", "dbo.Keg");
            DropIndex("dbo.Tap", new[] { "KegId" });
            DropIndex("dbo.Tap", new[] { "OfficeName" });
            DropTable("dbo.Tap");
            DropTable("dbo.Office");
            DropTable("dbo.Keg");
        }
    }
}
