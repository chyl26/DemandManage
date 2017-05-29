using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using REQM.Domain;
using REQM.Service;
using REQM.Helper;

namespace REQM.Controllers
{
    public class AccountController : Controller
    {
        private UserService userCRUD = new UserService();
        private User userLogin = new User();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logoff()
        {
            Session.Clear();//清空
            return RedirectToAction("Login", "Account");
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 登陆方法（Post表单）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(LoginView user)
        {
            if (ModelState.IsValid)//验证用户实体类中的条件是满足，密码不少于6位
            {
                userLogin.UserName = user.UserName;
                userLogin.PasswordHash = PasswordHelper.GetMd5HashStr(user.PasswordHash);

                User user1 = userCRUD.CheckUser(userLogin);
                if (user1 != null)
                {
                    //保存session
                    HttpContext.Session["UserID"] = user1.UserId;
                    Session["User"] = user1;
                    //string userID = HttpContext.Session["UserID"] as string;
                    return RedirectToAction("Index", "Product");
                }
                ModelState.AddModelError("", "用户名或密码错误，请重新输入！");
            }
            //将ModelState的验证结果传回视图
            return View(user);
        }
        /// <summary>
        /// 注册方法（Post表单）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (!userCRUD.VerifyUser(user.UserName))//判断用户名是否存在
                {
                    user.UserId = Guid.NewGuid().ToString();
                    user.PasswordHash = PasswordHelper.GetMd5HashStr(user.PasswordHash);
                    user.CreateAt = DateTime.Now;
                    userCRUD.Create(user);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "用户名已存在");
                }
            }
            //将ModelState的验证结果传回视图
            return View(user);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
    }
}