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
    public class OperatingDocController : Controller
    {
        public OperatingDocService DBCRUD = new OperatingDocService();
        public UserService userCRUD = new UserService();

        // GET: Operating
        public ActionResult Index()
        {
            return View(DBCRUD.GetOperatingDocs());
        }
        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            //将ProductId通过model传到前端
            OperatingDocModel model = new OperatingDocModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(OperatingDocModel operatingDoc)
        {
            if (ModelState.IsValid)
            {
                operatingDoc.OperatingId = Guid.NewGuid().ToString();
                operatingDoc.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                operatingDoc.UserId = userId;
                //将Models类转换成Domain类
                OperatingDoc toEntity = operatingDoc.ToEntity();
                DBCRUD.Create(toEntity);

                return RedirectToAction("Index", "OperatingDoc");
            }
            return View(operatingDoc);
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
            OperatingDoc operatingDoc = DBCRUD.GetOperatingDocById(Id);
            return View("Edit", operatingDoc.ToModel());
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OperatingDocModel operatingDoc)
        {
            if (ModelState.IsValid)
            {
                operatingDoc.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                operatingDoc.Reviser = userCRUD.GetUserById(userId).UserName;
                //将Models类转换成Domain类
                OperatingDoc toEntity = operatingDoc.ToEntity();
                DBCRUD.Update(toEntity);
                return RedirectToAction("Index", "OperatingDoc");
            }
            return View(operatingDoc);
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
            return RedirectToAction("Index", "OperatingDoc");
        }


        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingDoc operatingDoc = DBCRUD.GetOperatingDocById(Id);
            return View(operatingDoc.ToModel());
        }
    }
}