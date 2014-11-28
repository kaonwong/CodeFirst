namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategoryId = c.Int(nullable: false),
                        Token = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Remark = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropTable("dbo.Products");
        }
    }
}
