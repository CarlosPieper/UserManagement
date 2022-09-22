using UserManagement.Application.Services.Models.Request;
using UserManagement.Application.Services.Models.Response.Person;

namespace UserManagement.Application.Services.IService
{
    public interface IPersonService
    {
        Task<GetAllResponse> GetAllAsync();
        Task<GetByIdResponse> GetByIdAsync(int id);
        Task<CreateResponse> CreateAsync(PersonRequest request);
        Task<UpdateResponse> UpdateAsync(int id, PersonRequest request);
        Task<DeleteResponse> DeleteAsync(int id);
    }
}
