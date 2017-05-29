using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class ProductInfoService
    {
        IRepository<ProductInfo> repository = new MbRepository<ProductInfo>();

        /// <summary>
        /// 添加一个产品信息
        /// </summary>
        /// <param name="product"></param>
        public void Create(ProductInfo product)
        {
            repository.Insert("InsertProductInfo", product);
        }

        /// <summary>
        /// 通过ID查找一个产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductInfo GetProductById(string productId)
        {
            ProductInfo product = repository.GetByCondition("SelectProductInfoByCondition", new ProductInfo { ProductId = productId });
            return product;
        }

        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        public IList<ProductInfo> GetProducts()
        {
            IList<ProductInfo> productList = repository.GetList("SelectProductInfoByCondition", null);
            return productList;
        }

        /// <summary>
        /// 通过Id更新产品信息
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void Update(ProductInfo product)
        {
            repository.Update("UpdateProductInfo", product);
        }

        /// <summary>
        /// 通过Id删除产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public void Delete(string productId)
        {
            repository.Delete("DeleteProductInfo", productId);
        }
    }
}