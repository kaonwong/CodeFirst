using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models.Extension.Validation;

namespace CodeFirst.Models
{
    public partial class Product
    {
        [DisplayName("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { set; get; }

        [DisplayName("Product Category")]
        [Required]
        public int ProductCategoryId { set; get; }

        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        [Required]
        [Range(10, 9999)]
        public int Token { get; set; }

        [Required]
        [Range(0, 999)]
        public int Stock { get; set; }

        [DataType(DataType.Date)]
        [AdditionalMetadata("Parent","Product")]
        public Nullable<System.DateTime> StartDate { get; set; }

        [DataType(DataType.Date)]
        [AdditionalMetadata("Parent", "Product")]
        [DateCompare(ErrorMessage = "testing", CompareToPropertyName = "StartDate")]
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Remark { get; set; }

        [DisplayName("IsActive")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("CreatedAt")]
        [Required]
        public DateTime CreatedAt { get; set; }

        public Product()
        {
            this.IsActive = true;
            this.CreatedAt = DateTime.Now;
            this.Translations = new HashSet<ProductTranslation>();
        }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductTranslation> Translations { get; set; }

    }
}