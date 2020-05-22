namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergetest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CareerStatsQB",
                c => new
                    {
                        CareerQBId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        PassingYards = c.Int(nullable: false),
                        RushingYards = c.Int(nullable: false),
                        Completions = c.Int(nullable: false),
                        Attempts = c.Int(nullable: false),
                        PassingTouchdowns = c.Int(nullable: false),
                        RushingTouchdowns = c.Int(nullable: false),
                        Interceptions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CareerQBId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.CareerStatsRB",
                c => new
                    {
                        CareerRBId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        RushingYards = c.Int(nullable: false),
                        RushingAttempts = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        Receptions = c.Int(nullable: false),
                        RushingTouchdowns = c.Int(nullable: false),
                        ReceivingTouchdowns = c.Int(nullable: false),
                        Fumbles = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CareerRBId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.CareerStatsTE",
                c => new
                    {
                        CareerTEId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Receptions = c.Int(nullable: false),
                        Targets = c.Int(nullable: false),
                        Drops = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        YardsAfterCatch = c.Int(nullable: false),
                        Touchdowns = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CareerTEId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.SeasonStatRb",
                c => new
                    {
                        RbSeasonId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        RushingYards = c.Int(nullable: false),
                        RushingAttempts = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        Receptions = c.Int(nullable: false),
                        RushingTouchdowns = c.Int(nullable: false),
                        ReceivingTouchdowns = c.Int(nullable: false),
                        Fumbles = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RbSeasonId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.SeasonStat",
                c => new
                    {
                        SeasonId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        PassingYards = c.Int(nullable: false),
                        RushingYards = c.Int(nullable: false),
                        Completions = c.Int(nullable: false),
                        Attempts = c.Int(nullable: false),
                        PassingTouchdowns = c.Int(nullable: false),
                        RushingTouchdowns = c.Int(nullable: false),
                        Interceptions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeasonId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
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
            
            CreateTable(
                "dbo.SeasonStatWr",
                c => new
                    {
                        WrSeasonId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Receptions = c.Int(nullable: false),
                        Targets = c.Int(nullable: false),
                        Drops = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        YardsAfterCatch = c.Int(nullable: false),
                        Touchdowns = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WrSeasonId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeasonStatWr", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.SeasonStatTe", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.SeasonStat", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.SeasonStatRb", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.CareerStatsTE", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.CareerStatsRB", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.CareerStatsQB", "PlayerId", "dbo.Player");
            DropIndex("dbo.SeasonStatWr", new[] { "PlayerId" });
            DropIndex("dbo.SeasonStatTe", new[] { "PlayerId" });
            DropIndex("dbo.SeasonStat", new[] { "PlayerId" });
            DropIndex("dbo.SeasonStatRb", new[] { "PlayerId" });
            DropIndex("dbo.CareerStatsTE", new[] { "PlayerId" });
            DropIndex("dbo.CareerStatsRB", new[] { "PlayerId" });
            DropIndex("dbo.CareerStatsQB", new[] { "PlayerId" });
            DropTable("dbo.SeasonStatWr");
            DropTable("dbo.SeasonStatTe");
            DropTable("dbo.SeasonStat");
            DropTable("dbo.SeasonStatRb");
            DropTable("dbo.CareerStatsTE");
            DropTable("dbo.CareerStatsRB");
            DropTable("dbo.CareerStatsQB");
        }
    }
}
