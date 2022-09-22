using UserManagement.Application._Common;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using UserManagement.Domain.Model;
using UserManagement.Application.Services.IService;
using UserManagement.Application.Services.Models.Response.Person;
using UserManagement.Application.Services.Models.Request;
using UserManagement.Application.Services.Models.Dto;
using UserManagement.Persistence;

namespace UserManagement.Application.Services
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly MsSqlContext _db;
        private IMapper _mapper;
        public PersonService(ILogger<PersonService> logger, MsSqlContext db, IMapper mapper) : base(logger)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetAllResponse> GetAllAsync()
        {
            var entity = await _db.People.Select(a => new Person
            {
                Id = a.Id,
                Name = a.Name,
                Cpf = a.Cpf,
                CityId = a.CityId,
                City = new City
                {
                    Name = a.City.Name,
                    Uf = a.City.Uf
                },
            }).ToListAsync();
            return new GetAllResponse()
            {
                People = entity != null ? _mapper.Map<List<PersonDto>>(entity.Select(a => a).ToList()) : Enumerable.Empty<PersonDto>().ToList()
            };
        }

        public async Task<GetByIdResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdResponse();

            var entity = await _db.People.Select(a => new Person
            {
                Id = a.Id,
                Name = a.Name,
                Cpf = a.Cpf,
                CityId = a.CityId,
                City = new City
                {
                    Name = a.City.Name,
                    Uf = a.City.Uf
                },
            }).FirstOrDefaultAsync(item => item.Id == id);


            if (entity != null)
            {
                response.Person = _mapper.Map<PersonDto>(entity);
            }

            return response;
        }

        public async Task<CreateResponse> CreateAsync(PersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newExample = Person.Create(request.Name, request.Cpf, request.CityId, request.Age);

            _db.People.Add(newExample);

            await _db.SaveChangesAsync();

            return new CreateResponse() { Id = newExample.Id };
        }

        public async Task<UpdateResponse> UpdateAsync(int id, PersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.People.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Name, request.Cpf, request.CityId, request.Age);
                await _db.SaveChangesAsync();
            }

            return new UpdateResponse();
        }

        public async Task<DeleteResponse> DeleteAsync(int id)
        {

            var entity = await _db.People.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteResponse();
        }
    }
}
