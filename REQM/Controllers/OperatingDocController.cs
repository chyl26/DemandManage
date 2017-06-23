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

        // GET: RepData
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
        public ActionResult Create(OperatingDoc operatingDoc)
        {
            if (ModelState.IsValid)
            {
                repOther.RepOtherId = Guid.NewGuid().ToString();
                repOther.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repOther.UserId = userId;
                //将Models类转换成Domain类
                OperatingDoc toEntity = repOther.ToEntity();
                DBCRUD.Create(toEntity);

                return RedirectToAction("Details", "OperatingDoc", new { id = repOther.ProductId });
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
        public ActionResult Edit(OperatingDoc operatingDoc)
        {
            if (ModelState.IsValid)
            {
                operatingDoc.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                operatingDoc.Reviser = userId;
                //将Models类转换成Domain类
                OperatingDoc toEntity = operatingDoc.ToEntity();
                DBCRUD.Update(toEntity);
                return RedirectToAction("Details", "OperatingDoc", new { id = operatingDoc.ProductId });
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
            //获取删除的对象实体
            OperatingDoc operatingDoc = DBCRUD.GetOperatingDocById(Id);
            //删除数据库记录
            DBCRUD.Delete(Id);
            //返回上个界面
            return RedirectToAction("Details", "OperatingDoc", new { id = operatingDoc.ProductId });
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