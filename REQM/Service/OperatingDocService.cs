using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class OperatingDocService
    {
        IRepository<OperatingDoc> repository = new MbRepository<OperatingDoc>();

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="operatingDoc"></param>
        public void Create(OperatingDoc operatingDoc)
        {
            repository.Insert("InsertOperatingDoc", operatingDoc);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="operatingDoc"></param>
        public void Update(OperatingDoc operatingDoc)
        {
            repository.Update("UpdateOperatingDoc", operatingDoc);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(string Id)
        {
            repository.Delete("DeleteOperatingDoc", Id);
        }

        /// <summary>
        /// 通过ProductId获取功能性需求List
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<OperatingDoc> GetOperatingDocByProductId(string productId)
        {
            IList<OperatingDoc> operatingDocList = repository.GetList("SelectOperatingDocByProductId", new OperatingDoc { ProductId = productId });
            return operatingDocList;
        }

        /// <summary>
        /// 通过ID查找一个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OperatingDoc GetOperatingDocById(string operatingDocId)
        {
            OperatingDoc operatingDoc = repository.GetByCondition("SelectOperatingDocByDataId", new OperatingDoc { OperatingId = operatingDocId });
            return operatingDoc;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<OperatingDoc> GetOperatingDocs()
        {
            IList<OperatingDoc> operatingDocList = repository.GetList("SelectOperatingDocByCondition", null);
            return operatingDocList;
        }
    }
}