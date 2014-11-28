using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class SampleContext : DbContext
    {

        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductCategoryTranslation> ProductCategoryTranslation { get; set; }

        public SampleContext() : base("name=TestDB")
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}