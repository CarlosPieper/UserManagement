namespace UserManagement.Application.Services.Models.Request
{
    public class PersonRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
    }
}
