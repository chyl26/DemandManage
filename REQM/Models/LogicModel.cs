using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using REQM.Domain;

namespace REQM.Models
{
    public class LogicModel
    {
        public string ProductId { get; set; }

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

        public string UserId { get; set; }

        public string DisplayName { get; set; }
    }
}