﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Domain
{
    /// <summary>
    /// 交互需求实体类
    /// </summary>
    public class RepInteractive
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string InteractiveId { get; set; }

        [Required(ErrorMessage = "产品名称不能为空")]
        [Display(Name = "需求名称")]
        public string InteractiveName { get; set; }

        [Display(Name = "优先级")]
        public string Priority { get; set; }

        [Display(Name = "需求描述")]
        public string InteractiveDescribe { get; set; }

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