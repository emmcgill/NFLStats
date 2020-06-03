namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedNumberAndTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeasonStatRb", "PlayerNumber", c => c.Int(nullable: false));
            AddColumn("dbo.SeasonStatRb", "Team", c => c.String(nullable: false));
            AddColumn("dbo.SeasonStat", "PlayerNumber", c => c.Int(nullable: false));
            AddColumn("dbo.SeasonStat", "Team", c => c.String(nullable: false));
            AddColumn("dbo.SeasonStatTe", "PlayerNumber", c => c.Int(nullable: false));
            AddColumn("dbo.SeasonStatTe", "Team", c => c.String(nullable: false));
            AddColumn("dbo.SeasonStatWr", "PlayerNumber", c => c.Int(nullable: false));
            AddColumn("dbo.SeasonStatWr", "Team", c => c.String(nullable: false));
            DropColumn("dbo.Player", "PlayerNumber");
            DropColumn("dbo.Player", "YearsPro");
            DropColumn("dbo.Player", "Team");
            DropColumn("dbo.Player", "TotalVotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "TotalVotes", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "Team", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Player", "YearsPro", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "PlayerNumber", c => c.Int(nullable: false));
            DropColumn("dbo.SeasonStatWr", "Team");
            DropColumn("dbo.SeasonStatWr", "PlayerNumber");
            DropColumn("dbo.SeasonStatTe", "Team");
            DropColumn("dbo.SeasonStatTe", "PlayerNumber");
            DropColumn("dbo.SeasonStat", "Team");
            DropColumn("dbo.SeasonStat", "PlayerNumber");
            DropColumn("dbo.SeasonStatRb", "Team");
            DropColumn("dbo.SeasonStatRb", "PlayerNumber");
        }
    }
}
