using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Domain
{
    /// <summary>
    /// 非功能性需求模板
    /// </summary>
    public class RepOther
    {
        [Required(ErrorMessage = "产品编号不能为空")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "文档编号不能为空")]
        public string RepOtherId { get; set; }

        [Required(ErrorMessage = "文档名称不能为空")]
        [Display(Name = "文档名称")]
        public string RepOtherName { get; set; }

        [Display(Name = "优先级")]
        public string Priority { get; set; }

        [Display(Name = "需求描述")]
        public string RepOtherDescribe { get; set; }

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