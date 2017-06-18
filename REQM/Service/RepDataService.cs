using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class RepDataService
    {
        IRepository<RepData> repository = new MbRepository<RepData>();

        /// <summary>
        /// 创建一个
        /// </summary>
        /// <param name="repDetailed"></param>
        public void Create(RepData repData)
        {
            repository.Insert("InsertRepData", repData);
        }

        /// <summary>
        /// 通过Id更新产品信息
        /// </summary>
        /// <param name="repData"></param>
        /// <returns></returns>
        public void Update(RepData repData)
        {
            repository.Update("UpdateRepData", repData);
        }

        /// <summary>
        /// 通过Id删除产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public void Delete(string Id)
        {
            repository.Delete("DeleteRepData", Id);
        }

        /// <summary>
        /// 通过ProductId获取功能性需求List
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<RepData> GetRepDatasByProductId(string productId)
        {
            IList<RepData> repRepDatasList = repository.GetList("SelectRepDataByProductId", new RepData { ProductId = productId });
            return repRepDatasList;
        }

        /// <summary>
        /// 通过ID查找一个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RepData GetRepDataById(string repDataId)
        {
            RepData repDetailed = repository.GetByCondition("SelectRepDataByDataId", new RepData { DataId = repDataId });
            return repDetailed;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<RepData> GetRepDatas()
        {
            IList<RepData> repDataList = repository.GetList("SelectRepDataByCondition", null);
            return repDataList;
        }



    }
}