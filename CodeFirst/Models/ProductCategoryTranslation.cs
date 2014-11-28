using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public partial class ProductCategoryTranslation
    {
        [DisplayName("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [DisplayName("Language")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationResource))]
        public string Lang { get; set; }

        [Display(Name = "CategoryName", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationResource))]
        [StringLength(200)]
        public string Name { get; set; }

        public ProductCategoryTranslation()
        {

        }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}