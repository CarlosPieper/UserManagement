using UserManagement.Application._Common;
using UserManagement.Application.Services.Models.Dto;

namespace UserManagement.Application.Services.Models.Response.City
{
    public class GetAllResponse : BaseResponse
    {
        public List<CityDto> Cities { get; set; }
    }
}
