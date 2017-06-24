using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class HelpDocService
    {
        IRepository<HelpDoc> repository = new MbRepository<HelpDoc>();

        public void Create(HelpDoc helpDoc)
        {
            repository.Insert("InsertHelpDoc", helpDoc);
        }

        public void Update(HelpDoc helpDoc)
        {
            repository.Update("UpdateHelpDoc", helpDoc);
        }

        public void Delete(string Id)
        {
            repository.Delete("DeleteHelpDoc", Id);
        }

        /// <summary>
        /// 通过ProductId获取功能性需求List
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<HelpDoc> GetHelpDocByProductId(string productId)
        {
            IList<HelpDoc> helpDocList = repository.GetList("SelectHelpDocByProductId", new HelpDoc { ProductId = productId });
            return helpDocList;
        }

        /// <summary>
        /// 通过ID查找一个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HelpDoc GetHelpDocById(string operatingDocId)
        {
            HelpDoc helpDoc = repository.GetByCondition("SelectHelpDocByDataId", new HelpDoc { HelpDocId = operatingDocId });
            return helpDoc;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<HelpDoc> GetHelpDocs()
        {
            IList<HelpDoc> helpDoc = repository.GetList("SelectHelpDocByCondition", null);
            return helpDoc;
        }
    }
}