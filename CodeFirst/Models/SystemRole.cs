using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public partial class SystemRole
    {

        [DisplayName("ID")]
        [Key]
        [Required]
        public Guid ID { get; set; }

        [DisplayName("名稱")]
        [Required]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "長度不可小於 2")]
        [MaxLength(50, ErrorMessage = "長度不可超過 50")]
        public string Name { get; set; }

        [DisplayName("排序")]
        [Required]
        public int Sort { get; set; }

        [DisplayName("是否使用")]
        [Required]
        public bool IsEnable { get; set; }

        [DisplayName("建立時間")]
        public DateTime? CreatedAt { get; set; }

        [DisplayName("更新者")]
        public Guid? UpdateBy { get; set; }

        [DisplayName("更新時間")]
        public DateTime? UpdateOn { get; set; }

        public SystemRole()
        {
            this.ID = Guid.NewGuid();
            this.IsEnable = false;
            this.CreatedAt = DateTime.Now;
            this.SystemUsers = new List<SystemUser>();
        }

        public ICollection<SystemUser> SystemUsers { get; set; }

    }
}