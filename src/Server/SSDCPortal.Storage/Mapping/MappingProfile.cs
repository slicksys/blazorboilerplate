using AutoMapper.Configuration;
using SSDCPortal.Shared.Dto;
using SSDCPortal.Shared.Dto.Admin;
using SSDCPortal.Shared.Dto.Sample;
using Finbuckle.MultiTenant;
using ApiLogItem = SSDCPortal.Infrastructure.Storage.DataModels.ApiLogItem;
using Message = SSDCPortal.Infrastructure.Storage.DataModels.Message;

namespace SSDCPortal.Storage.Mapping
{
    public class MappingProfile : MapperConfigurationExpression
    {
        /// <summary>
        /// Create automap mapping profiles
        /// </summary>
        public MappingProfile()
        {
            CreateMap<TenantInfo, TenantDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
