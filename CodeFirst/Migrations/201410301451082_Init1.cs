namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SystemRoles", "CreatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SystemRoles", "CreatedAt");
        }
    }
}
