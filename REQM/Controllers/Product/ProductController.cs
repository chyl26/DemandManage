using REQM.Models;
using REQM.Domain;
using REQM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REQM.Helper;
using System.Net;

namespace REQM.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productCRUD = new ProductService();

        // GET: Product
        [Authentication]
        public ActionResult Index(int page = 1)
        {
            return View(productCRUD.GetProducts());
        }
        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productCRUD.GetProductById(Id);
            return View(product.ToModel());
        }
        [Authentication]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 产品立项
        /// </summary>
        /// <param name="product">立项信息</param>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productModel.ProductId = Guid.NewGuid().ToString();
                productModel.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                productModel.UserId= userId;
                //将Models类转换成Domain类
                Product product = productModel.ToEntity();
                productCRUD.Create(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "");
            return View(productModel);
        }
        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productCRUD.GetProductById(id);
            

            return View("Edit", product.ToModel());
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productModel.UpdateAt = DateTime.Now;
                Product product = productModel.ToEntity();
                productCRUD.Update(product);
                return RedirectToAction("Index");
            }
            return View(productModel);
        }
        [Authentication]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productCRUD.Delete(id);
            return RedirectToAction("Index");
        }
    }
}