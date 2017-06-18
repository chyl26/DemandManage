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
    public class RepOtherController : Controller
    {
        public RepOtherService DBCRUD = new RepOtherService();

        // GET: RepData
        public ActionResult Index()
        {
            return View(DBCRUD.GetRepOthers());
        }
        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            //将ProductId通过model传到前端
            RepOtherModel model = new RepOtherModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(RepOtherModel repOther)
        {
            if (ModelState.IsValid)
            {
                repOther.RepOtherId = Guid.NewGuid().ToString();
                repOther.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repOther.UserId = userId;
                //将Models类转换成Domain类
                RepOther toEntity = repOther.ToEntity();
                DBCRUD.Create(toEntity);

                return RedirectToAction("Details", "ProductInfo", new { id = repOther.ProductId });
            }
            return View(repOther);
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
            RepOther repOther = DBCRUD.GetRepOtherById(Id);
            return View("Edit", repOther.ToModel());
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepOtherModel repOther)
        {
            if (ModelState.IsValid)
            {
                repOther.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repOther.Reviser = userId;
                //将Models类转换成Domain类
                RepOther toEntity = repOther.ToEntity();
                DBCRUD.Update(toEntity);
                return RedirectToAction("Details", "ProductInfo", new { id = repOther.ProductId });
            }
            return View(repOther);
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
            RepOther repOther = DBCRUD.GetRepOtherById(Id);
            //删除数据库记录
            DBCRUD.Delete(Id);
            //返回上个界面
            return RedirectToAction("Details", "ProductInfo", new { id = repOther.ProductId });
        }


        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepOther repInteractive = DBCRUD.GetRepOtherById(Id);
            return View(repInteractive.ToModel());
        }
    }
}