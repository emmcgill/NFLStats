namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeSeasonStat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeasonStatTe",
                c => new
                    {
                        TeSeasonId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Receptions = c.Int(nullable: false),
                        Targets = c.Int(nullable: false),
                        Drops = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        YardsAfterCatch = c.Int(nullable: false),
                        Touchdowns = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeSeasonId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeasonStatTe", "PlayerId", "dbo.Player");
            DropIndex("dbo.SeasonStatTe", new[] { "PlayerId" });
            DropTable("dbo.SeasonStatTe");
        }
    }
}
