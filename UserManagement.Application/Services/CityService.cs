using UserManagement.Application._Common;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using UserManagement.Domain.Model;
using UserManagement.Application.Services.IService;
using UserManagement.Application.Services.Models.Response.City;
using UserManagement.Application.Services.Models.Dto;
using UserManagement.Application.Services.Models.Request;
using UserManagement.Persistence;

namespace UserManagement.Application.Services
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly MsSqlContext _db;
        private IMapper _mapper;
        public CityService(ILogger<CityService> logger, MsSqlContext db, IMapper mapper) : base(logger)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetAllResponse> GetAllAsync()
        {
            var entity = await _db.Cities.ToListAsync();
            return new GetAllResponse()
            {
                Cities = entity != null ? _mapper.Map<List<CityDto>>(entity) : Enumerable.Empty<CityDto>().ToList()
            };
        }

        public async Task<GetByIdResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdResponse();

            var entity = await _db.Cities.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                response.City = _mapper.Map<CityDto>(entity);
            }

            return response;
        }

        public async Task<CreateResponse> CreateAsync(CityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newExample = City.Create(request.Name, request.Uf);

            _db.Cities.Add(newExample);

            await _db.SaveChangesAsync();

            return new CreateResponse() { Id = newExample.Id };
        }

        public async Task<UpdateResponse> UpdateAsync(int id, CityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Cities.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Name, request.Uf);
                await _db.SaveChangesAsync();
            }

            return new UpdateResponse();
        }

        public async Task<DeleteResponse> DeleteAsync(int id)
        {

            var entity = await _db.Cities.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteResponse();
        }
    }
}
