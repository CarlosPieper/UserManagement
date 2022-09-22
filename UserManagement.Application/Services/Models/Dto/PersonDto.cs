using UserManagement.Application.Services.Models.Dto;

namespace UserManagement.Application.Services.Models.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }
        public int Age { get; set; }
    }
}
