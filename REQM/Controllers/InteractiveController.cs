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
    public class InteractiveController : Controller
    {
        private InteractiveService DBCRUD = new InteractiveService();

        // GET: Interactive
        public ActionResult Index()
        {
            return View();
        }
        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            //将ProductId通过model传到前端
            RepInteractiveModel model = new RepInteractiveModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(RepInteractiveModel repInteractive)
        {
            if (ModelState.IsValid)
            {
                repInteractive.InteractiveId = Guid.NewGuid().ToString();
                repInteractive.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repInteractive.UserId = userId;
                //将Models类转换成Domain类
                RepInteractive toEntity = repInteractive.ToEntity();
                DBCRUD.Create(toEntity);
                return RedirectToAction("Details", "ProductInfo", new { id = repInteractive.ProductId });
            }
            return View(repInteractive);
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
            RepInteractive repInteractive = DBCRUD.GetRepInteractiveById(Id);
            return View("Edit", repInteractive.ToModel());
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepInteractiveModel repInteractive)
        {
            if (ModelState.IsValid)
            {
                repInteractive.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repInteractive.Reviser = userId;
                //将Models类转换成Domain类
                RepInteractive toEntity = repInteractive.ToEntity();
                DBCRUD.Update(toEntity);
                return RedirectToAction("Details", "ProductInfo", new { id = repInteractive.ProductId });
            }
            return View(repInteractive);
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
            RepInteractive repInteractive = DBCRUD.GetRepInteractiveById(Id);
            //删除数据库记录
            DBCRUD.Delete(Id);
            //返回上个界面
            return RedirectToAction("Details", "ProductInfo", new { id = repInteractive.ProductId });
        }


        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepInteractive repInteractive = DBCRUD.GetRepInteractiveById(Id);
            return View(repInteractive.ToModel());
        }
    }
}