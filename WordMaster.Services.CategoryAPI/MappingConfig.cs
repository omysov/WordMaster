using AutoMapper;
using WordMaster.Services.CategoryAPI.Models;
using WordMaster.Services.CategoryAPI.Models.Dto;

namespace WordMaster.Services.CategoryAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoryDto, Category>();
                config.CreateMap<Category, CategoryDto>();
            });
            return mappingConfig;
        }
    }
}
