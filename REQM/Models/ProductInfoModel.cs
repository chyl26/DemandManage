using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REQM.Domain;
using System.ComponentModel.DataAnnotations;

namespace REQM.Models
{
    public class ProductInfoModel
    {
        [Display(Name = "产品编号")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "产品名称不能为空")]
        [Display(Name = "产品名称")]
        public string ProductName { get; set; }

        [Display(Name = "产品简介")]
        public string ProductIntro { get; set; }

        [Display(Name = "备注说明")]
        public string Explains { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateAt { get; set; }

        public User user { get; set; }

        [Display(Name = "产品逻辑描述")]
        public IList<Logic> Logics { get; set; }

        [Display(Name = "功能需求描述")]
        public IList<RepDetailed> RepDetaileds { get; set; }

        [Display(Name = "交互需求描述")]
        public IList<RepInteractive> Interactives { get; set; }

        [Display(Name = "数据需求描述")]
        public IList<RepData> Datas { get; set; }

        [Display(Name = "非功能性需求描述")]
        public IList<RepOther> RepOthers { get; set; }

        [Display(Name = "运营方案")]
        public IList<OperatingDoc> OperatingDocs { get; set; }

        [Display(Name = "客服文档")]
        public IList<HelpDoc> HelpDocs { get; set; }

        public string UserId { get; set; }

        public string DisplayName { get; set; }
    }
}