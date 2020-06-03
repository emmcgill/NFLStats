namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedTotalVotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "TotalVotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "TotalVotes");
        }
    }
}
