using AutoMapper;
using WordMaster.Services.LanguageAPI.Models;
using WordMaster.Services.LanguageAPI.Models.Dto;

namespace WordMaster.Services.LanguageAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LanguageDto, Language>();
                config.CreateMap<Language, LanguageDto>();
            });
            return mappingConfig;
        }
    }
}
