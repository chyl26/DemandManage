using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using REQM.Domain;
using REQM.Repository;
using REQM.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using REQM.Models;

namespace REQM.Service
{
    public class ProductService
    {
        IRepository<Product> repository = new MbRepository<Product>();

        /// <summary>
        /// 添加一个产品信息
        /// </summary>
        /// <param name="product"></param>
        public void Create(Product product)
        {
            repository.Insert("InsertProduct", product);
        }

        /// <summary>
        /// 通过ID查找一个产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductById(string productId)
        {
            Product product = repository.GetByCondition("SelectProductByCondition", new Product { ProductId = productId });
            return product;
        }

        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetProducts()
        {
            IList<Product> productList = repository.GetList("SelectProductByCondition", null);
            return productList;
        }

        /// <summary>
        /// 以分页形式获取所有产品
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Product> GetProduct(int index, int size)
        {
            IList<Product> productList = repository.GetList("SelectAllProduct", null, index, size);
            return productList;
        }

        /// <summary>
        /// 通过Id更新产品信息
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void Update(Product product)
        {
            repository.Update("UpdateProduct", product);
        }

        /// <summary>
        /// 通过Id删除产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public void Delete(string productId)
        {
            repository.Delete("DeleteProduct", productId);
        }
    }
}