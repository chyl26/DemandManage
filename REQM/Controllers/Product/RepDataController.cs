using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REQM.Domain;
using REQM.Models;
using REQM.Service;
using REQM.Helper;
using System.Net;

namespace REQM.Controllers
{
    public class RepDataController : Controller
    {
        public RepDataService DBCRUD = new RepDataService();

        // GET: RepData
        public ActionResult Index()
        {
            return View(DBCRUD.GetRepDatas());
        }
        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            //将ProductId通过model传到前端
            RepDataModel model = new RepDataModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(RepDataModel repData)
        {
            if (ModelState.IsValid)
            {
                repData.DataId = Guid.NewGuid().ToString();
                repData.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repData.UserId = userId;
                //将Models类转换成Domain类
                RepData toEntity = repData.ToEntity();
                DBCRUD.Create(toEntity);

                return RedirectToAction("Details", "ProductInfo", new { id = repData.ProductId });
            }
            return View(repData);
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
            RepData repInteractive = DBCRUD.GetRepDataById(Id);
            return View("Edit", repInteractive.ToModel());
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepDataModel repInteractive)
        {
            if (ModelState.IsValid)
            {
                repInteractive.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repInteractive.Reviser = userId;
                //将Models类转换成Domain类
                RepData toEntity = repInteractive.ToEntity();
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
            RepData repInteractive = DBCRUD.GetRepDataById(Id);
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
            RepData repInteractive = DBCRUD.GetRepDataById(Id);
            return View(repInteractive.ToModel());
        }
    }
}
