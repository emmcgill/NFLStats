namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedVoteController : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Vote", new[] { "playerId" });
            AlterColumn("dbo.Vote", "UserId", c => c.String());
            CreateIndex("dbo.Vote", "PlayerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vote", new[] { "PlayerId" });
            AlterColumn("dbo.Vote", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vote", "playerId");
        }
    }
}
