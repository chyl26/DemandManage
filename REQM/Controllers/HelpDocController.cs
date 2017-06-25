using REQM.Domain;
using REQM.Helper;
using REQM.Models;
using REQM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace REQM.Controllers
{
    public class HelpDocController : Controller
    {
        public HelpDocService DBCRUD = new HelpDocService();
        public UserService userCRUD = new UserService();

        // GET: RepData
        public ActionResult Index()
        {
            return View(DBCRUD.GetHelpDocs());
        }
        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            //将ProductId通过model传到前端
            HelpDocModel model = new HelpDocModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(HelpDocModel helpDoc)
        {
            if (ModelState.IsValid)
            {
                helpDoc.HelpDocId = Guid.NewGuid().ToString();
                helpDoc.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                helpDoc.UserId = userId;
                //将Models类转换成Domain类
                HelpDoc toEntity = helpDoc.ToEntity();
                DBCRUD.Create(toEntity);

                return RedirectToAction("Index", "HelpDoc");
            }
            return View(helpDoc);
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
            HelpDoc helpDoc = DBCRUD.GetHelpDocById(Id);
            return View("Edit", helpDoc.ToModel());
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HelpDocModel helpDoc)
        {
            if (ModelState.IsValid)
            {
                helpDoc.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                helpDoc.Reviser = userCRUD.GetUserById(userId).UserName;
                //将Models类转换成Domain类
                HelpDoc toEntity = helpDoc.ToEntity();
                DBCRUD.Update(toEntity);
                return RedirectToAction("Index", "HelpDoc");
            }
            return View(helpDoc);
        }
        #endregion

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns></returns>

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
            return RedirectToAction("Index", "HelpDoc");
        }


        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HelpDoc helpDoc = DBCRUD.GetHelpDocById(Id);
            return View(helpDoc.ToModel());
        }
    }
}