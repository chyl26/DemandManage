﻿using REQM.Domain;
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
    public class RepDetailedController : Controller
    {

        private RepDetailedService DBCRUD = new RepDetailedService();

        // GET: RepDetailed
        [Authentication]
        public ActionResult Index()
        {
            return View(DBCRUD.GetRepDetaileds());
        }

        #region  创建
        [Authentication]
        public ActionResult Create(string Id)
        {
            //将ProductId通过model传到前端
            RepDetailedModel model = new RepDetailedModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(RepDetailedModel repDetailed)
        {
            if (ModelState.IsValid)
            {
                repDetailed.RepDetailedId = Guid.NewGuid().ToString();
                repDetailed.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repDetailed.UserId = userId;
                //将Models类转换成Domain类
                RepDetailed toEntity = repDetailed.ToEntity();
                DBCRUD.Create(toEntity);
                return RedirectToAction("Details", "ProductInfo", new { id = repDetailed.ProductId });
            }
            return View(repDetailed);
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
            RepDetailed repDetailed = DBCRUD.GetRepDetailedById(Id);
            return View("Edit", repDetailed.ToModel());
        }

        [ValidateInput(false)]
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepDetailedModel repDetailed)
        {
            if (ModelState.IsValid)
            {
                repDetailed.UpdateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repDetailed.Reviser = userId;
                //将Models类转换成Domain类
                RepDetailed toEntity = repDetailed.ToEntity();
                DBCRUD.Update(toEntity);
                return RedirectToAction("Details", "ProductInfo", new { id = repDetailed.ProductId });
            }
            return View(repDetailed);
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
            RepDetailed repDetailed = DBCRUD.GetRepDetailedById(Id);
            //删除数据库记录
            DBCRUD.Delete(Id);
            //返回上个界面
            return RedirectToAction("Details", "ProductInfo", new { id = repDetailed.ProductId });
        }


        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepDetailed repDetailed = DBCRUD.GetRepDetailedById(Id);
            return View(repDetailed.ToModel());
        }


        #region  测试

        public ActionResult Summernote(string Id)
        {
            //将ProductId通过model传到前端
            RepDetailedModel model = new RepDetailedModel();
            model.ProductId = Id;
            //返回功能性需求Model
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Summernote(RepDetailedModel repDetailed)
        {
            if (ModelState.IsValid)
            {
                repDetailed.RepDetailedId = Guid.NewGuid().ToString();
                repDetailed.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repDetailed.UserId = userId;
                //将Models类转换成Domain类
                RepDetailed toEntity = repDetailed.ToEntity();
                DBCRUD.Create(toEntity);
                return RedirectToAction("Details", "ProductInfo", new { id = repDetailed.ProductId });
            }
            return View(repDetailed);
        }
        #endregion

    }
}