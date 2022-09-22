using UserManagement.Application._Common;
using UserManagement.Application.Services.Models.Dto;

namespace UserManagement.Application.Services.Models.Response.Person
{
    public class GetByIdResponse : BaseResponse
    {
        public PersonDto Person { get; set; }
    }
}
