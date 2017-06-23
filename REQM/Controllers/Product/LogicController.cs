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
    public class LogicController : Controller
    {
        private LogicService DBCRUD = new LogicService();
        // GET: Logic
        public ActionResult Index()
        {
            return View(DBCRUD.GetRepOthers());
        }
        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            //将ProductId通过model传到前端
            LogicModel model = new LogicModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(LogicModel logic)
        {
            if (ModelState.IsValid)
            {
                logic.LogicId = Guid.NewGuid().ToString();
                logic.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                logic.UserId = userId;
                //将Models类转换成Domain类
                Logic toEntity = logic.ToEntity();
                DBCRUD.Create(toEntity);

                return RedirectToAction("Details", "ProductInfo", new { id = logic.ProductId });
            }
            return View(logic);
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
            Logic logic = DBCRUD.GetLogicById(Id);
            return View("Edit", logic.ToModel());
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LogicModel logic)
        {
            if (ModelState.IsValid)
            {
                logic.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                logic.Reviser = userId;
                //将Models类转换成Domain类
                Logic toEntity = logic.ToEntity();
                DBCRUD.Update(toEntity);
                return RedirectToAction("Details", "ProductInfo", new { id = logic.ProductId });
            }
            return View(logic);
        }
        #endregion

        [Authentication]
        public ActionResult Delete(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //获取删除的对象实体
            Logic logic = DBCRUD.GetLogicById(Id);
            //删除数据库记录
            DBCRUD.Delete(Id);
            //返回上个界面
            return RedirectToAction("Details", "ProductInfo", new { id = logic.ProductId });
        }


        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logic logic = DBCRUD.GetLogicById(Id);
            return View(logic.ToModel());
        }
    }
}