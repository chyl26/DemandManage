using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REQM.Domain;
using REQM.Models;

namespace REQM.Helper
{
    /// <summary>
    /// 扩展类，用于数据类转换
    /// </summary>
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        //开始写扩展方法<初次使用，先到Global.asax中实例化一个实体类的实例(AutoMapperConfiguration.Init())>
        #region Product

        public static ProductModel ToModel(this Product entity)
        {
            return entity.MapTo<Product, ProductModel>();
        }

        public static Product ToEntity(this ProductModel model)
        {
            return model.MapTo<ProductModel, Product>();
        }

        #endregion

        #region  ProductInfo
        public static ProductInfoModel ToModel(this ProductInfo entity)
        {
            return entity.MapTo<ProductInfo, ProductInfoModel>();
        }

        public static ProductInfo ToEntity(this ProductInfoModel model)
        {
            return model.MapTo<ProductInfoModel, ProductInfo>();
        }
        #endregion

        #region  RepDetailed
        public static RepDetailedModel ToModel(this RepDetailed entity)
        {
            return entity.MapTo<RepDetailed, RepDetailedModel>();
        }

        public static RepDetailed ToEntity(this RepDetailedModel model)
        {
            return model.MapTo<RepDetailedModel, RepDetailed>();
        }
        #endregion
    }
}