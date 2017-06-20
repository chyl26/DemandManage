using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class LogicService
    {
        IRepository<Logic> repository = new MbRepository<Logic>();

        /// <summary>
        /// 创建一个
        /// </summary>
        /// <param name="repDetailed"></param>
        public void Create(Logic logic)
        {
            repository.Insert("InsertLogic", logic);
        }

        /// <summary>
        /// 通过Id更新产品信息
        /// </summary>
        /// <param name="repData"></param>
        /// <returns></returns>
        public void Update(Logic logic)
        {
            repository.Update("UpdateLogic", logic);
        }

        /// <summary>
        /// 通过Id删除产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public void Delete(string Id)
        {
            repository.Delete("DeleteLogic", Id);
        }

        /// <summary>
        /// 通过ProductId获取功能性需求List
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<Logic> GetLogicsByProductId(string productId)
        {
            IList<Logic> repOthersList = repository.GetList("SelectLogicByProductId", new Logic { ProductId = productId });
            return repOthersList;
        }

        /// <summary>
        /// 通过ID查找一个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Logic GetLogicById(string logicId)
        {
            Logic logic = repository.GetByCondition("SelectLogicByDataId", new Logic { LogicId = logicId });
            return logic;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<Logic> GetRepOthers()
        {
            IList<Logic> logicList = repository.GetList("SelectLogicByCondition", null);
            return logicList;
        }
    }
}