namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        PlayerPosition = c.String(nullable: false, maxLength: 30),
                        TotalVotes = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PlayerId);
            
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
                "dbo.CareerStatsWR",
                c => new
                    {
                        CareerWRId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Receptions = c.Int(nullable: false),
                        Targets = c.Int(nullable: false),
                        Drops = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        YardsAfterCatch = c.Int(nullable: false),
                        Touchdowns = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CareerWRId)
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
                        IsDeleted = c.Boolean(nullable: false),
                        PlayerNumber = c.Int(nullable: false),
                        Team = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RbSeasonId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                        IsDeleted = c.Boolean(nullable: false),
                        PlayerNumber = c.Int(nullable: false),
                        Team = c.String(nullable: false),
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
                        IsDeleted = c.Boolean(nullable: false),
                        PlayerNumber = c.Int(nullable: false),
                        Team = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeSeasonId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        PlayerId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VoteId)
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
                        IsDeleted = c.Boolean(nullable: false),
                        PlayerNumber = c.Int(nullable: false),
                        Team = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WrSeasonId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeasonStatWr", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.Vote", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.SeasonStatTe", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.SeasonStat", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.SeasonStatRb", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.CareerStatsWR", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.CareerStatsTE", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.CareerStatsRB", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.CareerStatsQB", "PlayerId", "dbo.Player");
            DropIndex("dbo.SeasonStatWr", new[] { "PlayerId" });
            DropIndex("dbo.Vote", new[] { "PlayerId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SeasonStatTe", new[] { "PlayerId" });
            DropIndex("dbo.SeasonStat", new[] { "PlayerId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.SeasonStatRb", new[] { "PlayerId" });
            DropIndex("dbo.CareerStatsWR", new[] { "PlayerId" });
            DropIndex("dbo.CareerStatsTE", new[] { "PlayerId" });
            DropIndex("dbo.CareerStatsRB", new[] { "PlayerId" });
            DropIndex("dbo.CareerStatsQB", new[] { "PlayerId" });
            DropTable("dbo.SeasonStatWr");
            DropTable("dbo.Vote");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.SeasonStatTe");
            DropTable("dbo.SeasonStat");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.SeasonStatRb");
            DropTable("dbo.CareerStatsWR");
            DropTable("dbo.CareerStatsTE");
            DropTable("dbo.CareerStatsRB");
            DropTable("dbo.Player");
            DropTable("dbo.CareerStatsQB");
        }
    }
}
