using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Domain
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class User
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "账号不能为空")]
        [RegularExpression(@"^[a-zA-Z]{1,1}[a-zA-Z0-9_]{5,14}$", ErrorMessage = "只包含字母、数字和下划线的6-16位字符，而且只能是以字母开头")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        [Required] //必填项
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DisplayName("密  码")] //显示在Label上的名字
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("PasswordHash", ErrorMessage = "两次输入的密码不一致")]
        public string VerifyPassWord { get; set; }

        [Display(Name = "电子邮箱")]
        [EmailAddress]
        [RegularExpression(@"^(\w{1,})@(\w{1,5}).(\w{1,5})$", ErrorMessage = "请输入正确的Email，提高密码的高效性")]
        public string Email { get; set; }

        [Display(Name = "手 机 号")]
        public string MobilePhone { get; set; }

        public DateTime CreateAt { get; set; }
    }
    public class LoginView
    {
        [Required(ErrorMessage = "账号不能为空")]
        [RegularExpression(@"^[a-zA-Z]{1,1}[a-zA-Z0-9_]{5,14}$", ErrorMessage = "只包含字母、数字和下划线的6-16位字符，而且只能是以字母开头")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        [Required] //必填项
        [DataType(DataType.Password)]
        [DisplayName("密  码")] //显示在Label上的名字
        public string PasswordHash { get; set; }
    }
}