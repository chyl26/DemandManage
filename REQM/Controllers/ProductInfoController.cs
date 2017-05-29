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
    public class ProductInfoController : Controller
    {
        private ProductInfoService productInfoCRUD = new ProductInfoService();
        private RepDetailedService repDetailedCRUD = new RepDetailedService();

        // GET: ProductInfo
        [Authentication]
        public ActionResult Index()
        {
            return View(productInfoCRUD.GetProducts());
        }

        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo product = productInfoCRUD.GetProductById(Id);
            product.RepDetaileds = new List<RepDetailed>();
            product.RepDetaileds = repDetailedCRUD.GetRepDetailedsByProductId(Id);

            return View(product.ToModel());
        }
        #region 创建
        [Authentication]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(ProductInfoModel productInfoModel)
        {
            if (ModelState.IsValid)
            {
                productInfoModel.ProductId = Guid.NewGuid().ToString();
                productInfoModel.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                productInfoModel.UserId = userId;
                //将Models类转换成Domain类
                ProductInfo product = productInfoModel.ToEntity();
                productInfoCRUD.Create(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "");
            return View(productInfoModel);
        }
        #endregion

        #region  编辑
        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo product = productInfoCRUD.GetProductById(id);


            return View("Edit", product.ToModel());
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ProductInfoModel productInfoModel)
        {
            if (ModelState.IsValid)
            {
                ProductInfo product = productInfoModel.ToEntity();
                productInfoCRUD.Update(product);
                return RedirectToAction("Index");
            }
            return View(productInfoModel);
        }
        #endregion

        [Authentication]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productInfoCRUD.Delete(id);
            return RedirectToAction("Index");
        }

        [Authentication]
        public ActionResult Document(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo product = productInfoCRUD.GetProductById(Id);
            return View(product.ToModel());
        }
    }
}