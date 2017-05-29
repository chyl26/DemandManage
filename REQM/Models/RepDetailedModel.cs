using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Models
{
    public class RepDetailedModel
    {
        public string ProductId { get; set; }

        public string RepDetailedId { get; set; }

        [Required(ErrorMessage = "产品名称不能为空")]
        [Display(Name = "需求名称")]
        public string RepName { get; set; }

        [Display(Name = "优先级")]
        public string Priority { get; set; }

        [Display(Name = "需求描述")]
        public string RepDescribe { get; set; }

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