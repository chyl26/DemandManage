using REQM.Domain;
using REQM.Helper;
using REQM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace REQM.Controllers
{
    public class UserController : Controller
    {
        private UserService DBCRUD = new UserService();
        // GET: User
        public ActionResult Index()
        {
            return View(DBCRUD.GetUsers());
        }
        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (DBCRUD.VerifyUser(user.UserName))//判断用户名是否存在
                {
                    user.UserId = Guid.NewGuid().ToString();
                    user.PasswordHash = PasswordHelper.GetMd5HashStr(user.PasswordHash);
                    user.CreateAt = DateTime.Now;
                    DBCRUD.Create(user);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "用户名已存在");
                }
            }
            return View(user);
        }
        #endregion

        #region 编辑
        [Authentication]
        public ActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DBCRUD.GetUserById(Id);
            return View("Edit",user);
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                    user.PasswordHash = PasswordHelper.GetMd5HashStr(user.PasswordHash);
                    user.CreateAt = DateTime.Now;
                    DBCRUD.Update(user);
                    return RedirectToAction("Index");
            }
            return View(user);
        }
        #endregion

        [Authentication]
        public ActionResult Delete(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //删除数据库记录
            DBCRUD.Delete(Id);
            //返回上个界面
            return RedirectToAction("Index");
        }


        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DBCRUD.GetUserById(Id);
            return View(user);
        }
    }
}