using System.ComponentModel.DataAnnotations;

namespace ApiMakeUpStore.Data.Dtos.Brand
{
    public class ReadBrandDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }
}
