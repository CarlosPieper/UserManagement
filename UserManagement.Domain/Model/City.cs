using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Domain.Model
{
    [Table("City")]
    public class City
    {
        public City() { }
        private City(string name, string uf)
        {
            this.Name = name;
            this.Uf = uf;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        [Column("Name")]
        public string Name { get; set; }
        [MaxLength(2)]
        [Required]
        [Column("Uf")]
        public string Uf { get; set; }

        public static City Create(string name, string uf)
        {
            if (name is null)
            {
                throw new ArgumentException("Invalid " + nameof(name));
            }

            if (uf is null)
            {
                throw new ArgumentException("Invalid " + nameof(uf));
            }

            return new City(name, uf);
        }

        public void Update(string name, string uf)
        {
            if (name is not null)
            {
                Name = name;
            }

            if (uf is not null)
            {
                Uf = uf;
            }
        }
    }
}
