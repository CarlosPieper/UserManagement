using AutoMapper;
using UserManagement.Application.Services.Models.Dto;
using UserManagement.Domain.Model;

namespace UserManagement.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonDto, Person>().ReverseMap();
                config.CreateMap<CityDto, City>().ReverseMap();
            });
            return mappingConfig;
        }
    }

}
