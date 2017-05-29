using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REQM.Domain;
using System.ComponentModel.DataAnnotations;

namespace REQM.Models
{
    public class ProductModel
    {
        public string ProductId { get; set; }

        [Required(ErrorMessage = "产品名称不能为空")]
        [Display(Name = "产品名称")]
        public string ProductName { get; set; }

        [Display(Name = "产品逻辑说明")]
        public string Productlogic { get; set; }

        [Display(Name = "产品特性")]
        public string Characteristic { get; set; }

        [Display(Name = "需求详细说明")]
        public List<RepDetailed> Detaileds { get; set; }

        [Display(Name = "交互需求说明")]
        public string Interactive { get; set; }

        [Display(Name = "数据需求")]
        public string DateRep { get; set; }

        [Display(Name = "其它需求")]
        public string OtherRep { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateAt { get; set; }

        [Display(Name = "更新时间")]
        public DateTime UpdateAt { get; set; }

        public string UserId { get; set; }

        public string DisplayName { get; set; }
    }
}