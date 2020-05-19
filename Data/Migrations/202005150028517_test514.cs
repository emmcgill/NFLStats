namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test514 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vote", "userId", c => c.Int(nullable: false));
            DropColumn("dbo.Vote", "ownerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "ownerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Vote", "userId");
        }
    }
}
