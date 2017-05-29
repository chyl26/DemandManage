using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Domain
{
    /// <summary>
    /// 客服文档
    /// </summary>
    public class HelpDoc
    {
        [Required(ErrorMessage ="产品编号不能为空")]
        public string ProductId { get; set; }

        [Required(ErrorMessage ="文档编号不能为空")]
        public string HelpDocId { get; set; }

        [Required(ErrorMessage = "文档名称不能为空")]
        [Display(Name = "文档名称")]
        public string HelpDocName { get; set; }

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