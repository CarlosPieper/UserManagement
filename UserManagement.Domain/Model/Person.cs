using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Domain.Model
{
    [Table("Person")]
    public sealed class Person
    {
        public Person() { }
        private Person(string name, string cpf, int cityId, int age)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.CityId = cityId;
            this.Age = age;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(11)]
        [Required]
        [Column("Cpf")]
        public string Cpf { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        [Required]
        [Column("Age")]
        public int Age { get; set; }

        public static Person Create(string name, string cpf, int cityId, int age)
        {
            if (name is null)
            {
                throw new ArgumentException("Invalid " + nameof(name));
            }

            if (cpf is null)
            {
                throw new ArgumentException("Invalid " + nameof(cpf));
            }

            return new Person(name, cpf, cityId, age);
        }

        public void Update(string name, string cpf, int cityId, int age)
        {
            if (name is not null)
            {
                Name = name;
            }

            if (cpf is not null)
            {
                Cpf = cpf;
            }

            CityId = cityId;
            Age = age;
        }
    }
}
