using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class RepOtherService
    {
        IRepository<RepOther> repository = new MbRepository<RepOther>();

        /// <summary>
        /// 创建一个
        /// </summary>
        /// <param name="repDetailed"></param>
        public void Create(RepOther repOther)
        {
            repository.Insert("InsertRepOther", repOther);
        }

        /// <summary>
        /// 通过Id更新产品信息
        /// </summary>
        /// <param name="repData"></param>
        /// <returns></returns>
        public void Update(RepOther repOther)
        {
            repository.Update("UpdateRepOther", repOther);
        }

        /// <summary>
        /// 通过Id删除产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public void Delete(string Id)
        {
            repository.Delete("DeleteRepOther", Id);
        }

        /// <summary>
        /// 通过ProductId获取功能性需求List
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<RepOther> GetRepOthersByProductId(string productId)
        {
            IList<RepOther> repOthersList = repository.GetList("SelectRepOtherByProductId", new RepOther { ProductId = productId });
            return repOthersList;
        }

        /// <summary>
        /// 通过ID查找一个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RepOther GetRepOtherById(string repOtherId)
        {
            RepOther repDetailed = repository.GetByCondition("SelectRepOtherByDataId", new RepOther { RepOtherId = repOtherId });
            return repDetailed;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<RepOther> GetRepOthers()
        {
            IList<RepOther> repOtherList = repository.GetList("SelectRepOtherByCondition", null);
            return repOtherList;
        }
    }
}