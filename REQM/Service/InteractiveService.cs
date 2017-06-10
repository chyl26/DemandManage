using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class InteractiveService
    {
        IRepository<RepInteractive> repository = new MbRepository<RepInteractive>();

        public void Create(RepInteractive repInteractive)
        {
            repository.Insert("InsertRepInteractive", repInteractive);
        }
        /// <summary>
        /// 通过ID查找一个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RepInteractive GetRepInteractiveById(string interactiveId)
        {
            RepInteractive repInteractive = repository.GetByCondition("SelectRepInteractiveByInteractiveId", new RepInteractive { InteractiveId = interactiveId });
            return repInteractive;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<RepInteractive> GetInteractives()
        {
            IList<RepInteractive> interactiveList = repository.GetList("SelectInteractiveByCondition", null);
            return interactiveList;
        }
        /// <summary>
        /// 通过ProductId获取功能性需求List
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<RepInteractive> GetInteractivesByProductId(string Id)
        {
            IList<RepInteractive> repDetailedList = repository.GetList("SelectRepInteractiveByProductId", new RepInteractive { ProductId = Id });//new RepInteractive 创建一个实体的Id
            return repDetailedList;
        }

        /// <summary>
        /// 通过Id更新信息
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void Update(RepInteractive repInteractive)
        {
            repository.Update("UpdateRepInteractive", repInteractive);
        }

        /// <summary>
        /// 通过Id删除产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public void Delete(string Id)
        {
            repository.Delete("DeleteRepInteractive", Id);
        }
    }
}