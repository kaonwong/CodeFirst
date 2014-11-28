namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SystemUsers", "CreateOn");
            DropColumn("dbo.SystemRoles", "CreateOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SystemRoles", "CreateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.SystemUsers", "CreateOn", c => c.DateTime(nullable: false));
        }
    }
}
