using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public partial class ProductCategory
    {
        [DisplayName("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [DisplayName("IsActive")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("CreatedAt")]
        [Required]
        public DateTime CreatedAt { get; set; }

        public ProductCategory()
        {
            this.IsActive = true;
            this.CreatedAt = DateTime.Now;
            this.Translations = new HashSet<ProductCategoryTranslation>();
            this.Products = new HashSet<Product>();
        }

        public virtual ICollection<ProductCategoryTranslation> Translations { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}