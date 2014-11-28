namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTranslations", "Description", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductTranslations", "Description");
        }
    }
}
