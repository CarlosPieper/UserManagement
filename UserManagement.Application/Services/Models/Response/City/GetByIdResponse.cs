using UserManagement.Application._Common;
using UserManagement.Application.Services.Models.Dto;

namespace UserManagement.Application.Services.Models.Response.City
{
    public class GetByIdResponse : BaseResponse
    {
        public CityDto City { get; set; }
    }
}
