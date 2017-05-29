using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Domain
{
    /// <summary>
    /// 运营策划文档
    /// </summary>
    public class OperatingDoc
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string OperatingId { get; set; }

        [Required(ErrorMessage = "文档名称不能为空")]
        [Display(Name = "文档名称")]
        public string OperatingName { get; set; }

        [Display(Name = "文档内容")]
        public string Content { get; set; }

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