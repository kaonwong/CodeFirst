﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public partial class SystemUser
    {

        [DisplayName("ID")]
        [Key]
        [Required]
        public Guid ID { get; set; }

        [DisplayName("帳號")]
        [Required]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "長度不可小於 5")]
        [MaxLength(50, ErrorMessage = "長度不可超過 50")]
        public string Account { get; set; }

        [DisplayName("密碼")]
        [Required]
        [StringLength(200)]
        [MinLength(5, ErrorMessage = "長度不可小於 5")]
        [MaxLength(200, ErrorMessage = "長度不可超過 200")]
        public string Password { get; set; }

        [DisplayName("名稱")]
        [Required]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "長度不可小於 2")]
        [MaxLength(50, ErrorMessage = "長度不可超過 50")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required]
        [StringLength(200)]
        [MinLength(2, ErrorMessage = "長度不可小於 2")]
        [MaxLength(200, ErrorMessage = "長度不可超過 200")]
        public string Email { get; set; }

        [DisplayName("是否使用")]
        [Required]
        public bool IsEnable { get; set; }

        [DisplayName("更新者")]
        public Guid? UpdateBy { get; set; }

        [DisplayName("更新時間")]
        public DateTime? UpdateOn { get; set; }

        public SystemUser()
        {
            this.ID = Guid.NewGuid();
            this.IsEnable = false;
            this.SystemRoles = new List<SystemRole>();
        }

        public ICollection<SystemRole> SystemRoles { get; set; }

    }
}