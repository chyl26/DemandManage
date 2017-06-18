using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Domain
{
    public class Logic
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string LogicId { get; set; }

        [Required(ErrorMessage = "逻辑名称不能为空")]
        [Display(Name = "逻辑名称")]
        public string LogicName { get; set; }

        [Display(Name = "逻辑描述")]
        public string LogicDescribe { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateAt { get; set; }

        [Display(Name = "修订人")]
        public string Reviser { get; set; }

        [Display(Name = "更新时间")]
        public DateTime UpdateAt { get; set; }

        [Display(Name = "更新记录")]
        public string Revision { get; set; }

        public User user { get; set; }
    }
}