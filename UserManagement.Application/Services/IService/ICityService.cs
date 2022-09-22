using UserManagement.Application.Services.Models.Request;
using UserManagement.Application.Services.Models.Response.City;

namespace UserManagement.Application.Services.IService
{
    public interface ICityService
    {
        Task<GetAllResponse> GetAllAsync();
        Task<GetByIdResponse> GetByIdAsync(int id);
        Task<CreateResponse> CreateAsync(CityRequest request);
        Task<UpdateResponse> UpdateAsync(int id, CityRequest request);
        Task<DeleteResponse> DeleteAsync(int id);
    }
}
