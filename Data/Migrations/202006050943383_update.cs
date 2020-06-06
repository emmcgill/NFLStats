namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CareerStatsQB", "Name", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CareerStatsRB", "Name", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CareerStatsTE", "Name", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CareerStatsWR", "Name", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.CareerStatsQB", "PassingYards");
            DropColumn("dbo.CareerStatsQB", "RushingYards");
            DropColumn("dbo.CareerStatsQB", "Completions");
            DropColumn("dbo.CareerStatsQB", "Attempts");
            DropColumn("dbo.CareerStatsQB", "PassingTouchdowns");
            DropColumn("dbo.CareerStatsQB", "RushingTouchdowns");
            DropColumn("dbo.CareerStatsQB", "Interceptions");
            DropColumn("dbo.CareerStatsRB", "RushingYards");
            DropColumn("dbo.CareerStatsRB", "RushingAttempts");
            DropColumn("dbo.CareerStatsRB", "ReceivingYards");
            DropColumn("dbo.CareerStatsRB", "Receptions");
            DropColumn("dbo.CareerStatsRB", "RushingTouchdowns");
            DropColumn("dbo.CareerStatsRB", "ReceivingTouchdowns");
            DropColumn("dbo.CareerStatsRB", "Fumbles");
            DropColumn("dbo.CareerStatsTE", "Year");
            DropColumn("dbo.CareerStatsTE", "Receptions");
            DropColumn("dbo.CareerStatsTE", "Targets");
            DropColumn("dbo.CareerStatsTE", "Drops");
            DropColumn("dbo.CareerStatsTE", "ReceivingYards");
            DropColumn("dbo.CareerStatsTE", "YardsAfterCatch");
            DropColumn("dbo.CareerStatsTE", "Touchdowns");
            DropColumn("dbo.CareerStatsWR", "Receptions");
            DropColumn("dbo.CareerStatsWR", "Targets");
            DropColumn("dbo.CareerStatsWR", "Drops");
            DropColumn("dbo.CareerStatsWR", "ReceivingYards");
            DropColumn("dbo.CareerStatsWR", "YardsAfterCatch");
            DropColumn("dbo.CareerStatsWR", "Touchdowns");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CareerStatsWR", "Touchdowns", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsWR", "YardsAfterCatch", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsWR", "ReceivingYards", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsWR", "Drops", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsWR", "Targets", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsWR", "Receptions", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsTE", "Touchdowns", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsTE", "YardsAfterCatch", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsTE", "ReceivingYards", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsTE", "Drops", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsTE", "Targets", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsTE", "Receptions", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsTE", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsRB", "Fumbles", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsRB", "ReceivingTouchdowns", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsRB", "RushingTouchdowns", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsRB", "Receptions", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsRB", "ReceivingYards", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsRB", "RushingAttempts", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsRB", "RushingYards", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsQB", "Interceptions", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsQB", "RushingTouchdowns", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsQB", "PassingTouchdowns", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsQB", "Attempts", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsQB", "Completions", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsQB", "RushingYards", c => c.Int(nullable: false));
            AddColumn("dbo.CareerStatsQB", "PassingYards", c => c.Int(nullable: false));
            DropColumn("dbo.CareerStatsWR", "Name");
            DropColumn("dbo.CareerStatsTE", "Name");
            DropColumn("dbo.CareerStatsRB", "Name");
            DropColumn("dbo.CareerStatsQB", "Name");
        }
    }
}
