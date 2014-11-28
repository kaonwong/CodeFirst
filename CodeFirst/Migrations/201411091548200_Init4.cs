namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Lang = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductTranslations", new[] { "ProductId" });
            DropForeignKey("dbo.ProductTranslations", "ProductId", "dbo.Products");
            DropTable("dbo.ProductTranslations");
        }
    }
}
