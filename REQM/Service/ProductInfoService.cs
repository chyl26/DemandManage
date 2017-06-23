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

        private RepDetailedService repDetailedCRUD = new RepDetailedService();
        private InteractiveService InteractiveCRUD = new InteractiveService();
        private RepDataService repDataCRUD = new RepDataService();
        private RepOtherService repOtherCRUD = new RepOtherService();
        private LogicService logicCRUD = new LogicService();

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
            
            //获取产品逻辑说明List
            product.Logics = new List<Logic>();
            product.Logics = logicCRUD.GetLogicsByProductId(productId);

            //获取功能性需求详情List
            product.RepDetaileds = new List<RepDetailed>();
            product.RepDetaileds = repDetailedCRUD.GetRepDetailedsByProductId(productId);

            //获取交互需求详情List
            product.Interactives = new List<RepInteractive>();
            product.Interactives = InteractiveCRUD.GetInteractivesByProductId(productId);

            //获取数据需求详情List
            product.Datas = new List<RepData>();
            product.Datas = repDataCRUD.GetRepDatasByProductId(productId);

            //获取非功能性需求详情List
            product.RepOthers = new List<RepOther>();
            product.RepOthers = repOtherCRUD.GetRepOthersByProductId(productId);

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