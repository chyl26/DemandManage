using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REQM.Domain;
using REQM.Models;
using AutoMapper;

namespace REQM.Helper
{
    public class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        //映射配置文件
        static Action<IMapperConfigurationExpression> action = cfg =>
        {
            #region  Product
            //将Domain映射到ViewProduct
            cfg.CreateMap<Product, ProductModel>()
            //dest表示ViewProduct中的属性，src表示Domain
            .ForMember(dest => dest.UserId, mo => mo.MapFrom(src => src.user.UserId))
            .ForMember(dest => dest.DisplayName, mo => mo.MapFrom(src => src.user.DisplayName));

            //将ViewProduct映射到Domain
            cfg.CreateMap<ProductModel, Product>()
            .ForMember(dest => dest.user, mo => mo.MapFrom(src => new User { UserId = src.UserId }));
            #endregion

            #region  ProductInfo
            cfg.CreateMap<ProductInfo, ProductInfoModel>()
            //dest表示ViewProduct中的属性，src表示Domain
            .ForMember(dest => dest.UserId, mo => mo.MapFrom(src => src.user.UserId))
            .ForMember(dest => dest.DisplayName, mo => mo.MapFrom(src => src.user.DisplayName));

            //将ViewProduct映射到Domain
            cfg.CreateMap<ProductInfoModel, ProductInfo>()
            .ForMember(dest => dest.user, mo => mo.MapFrom(src => new User { UserId = src.UserId }));
            #endregion

            #region  RepDetailed
            cfg.CreateMap<RepDetailed, RepDetailedModel>()
            //dest表示ViewProduct中的属性，src表示Domain
            .ForMember(dest => dest.UserId, mo => mo.MapFrom(src => src.user.UserId))
            .ForMember(dest => dest.DisplayName, mo => mo.MapFrom(src => src.user.DisplayName));

            //将ViewProduct映射到Domain
            cfg.CreateMap<RepDetailedModel, RepDetailed>()
            .ForMember(dest => dest.user, mo => mo.MapFrom(src => new User { UserId = src.UserId }));
            #endregion

            #region  RepInteractive
            cfg.CreateMap<RepInteractive, RepInteractiveModel>()
            //dest表示ViewProduct中的属性，src表示Domain
            .ForMember(dest => dest.UserId, mo => mo.MapFrom(src => src.user.UserId))
            .ForMember(dest => dest.DisplayName, mo => mo.MapFrom(src => src.user.DisplayName));

            //将ViewProduct映射到Domain
            cfg.CreateMap<RepInteractiveModel, RepInteractive>()
            .ForMember(dest => dest.user, mo => mo.MapFrom(src => new User { UserId = src.UserId }));
            #endregion

        };

        public static void Init()
        {
            //初始化配置文件,生成IMapper对象用于执行转换
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                action(cfg);
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// 单例
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
    }
}