namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vote", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Vote", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vote", "IsDeleted");
            DropColumn("dbo.Vote", "ModifiedUtc");
        }
    }
}
