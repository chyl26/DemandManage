using REQM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Models
{
    public class HelpDocModel
    {
        public string ProductId { get; set; }


        public string HelpDocId { get; set; }

        [Required(ErrorMessage = "文档标题不能为空")]
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

        public string UserId { get; set; }

        public string DisplayName { get; set; }
    }
}