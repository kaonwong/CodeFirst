using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public partial class ProductTranslation
    {
        [DisplayName("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [DisplayName("Language")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationResource))]
        public string Lang { get; set; }

        [Display(Name = "ProductName", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationResource))]
        [StringLength(200)]
        public string Name { get; set; }

        [Display(Name = "ProductDescription", ResourceType = typeof(Resources.Resource))]
        [Column(TypeName = "ntext")]
        [MaxLength]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationResource))]
        public string Description { get; set; }

        public ProductTranslation()
        {

        }

        public virtual Product Product { get; set; }
    }
}