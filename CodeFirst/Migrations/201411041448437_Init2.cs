namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategoryTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategoryId = c.Int(nullable: false),
                        Lang = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductCategoryTranslations", new[] { "ProductCategoryId" });
            DropForeignKey("dbo.ProductCategoryTranslations", "ProductCategoryId", "dbo.ProductCategories");
            DropTable("dbo.ProductCategoryTranslations");
            DropTable("dbo.ProductCategories");
        }
    }
}
