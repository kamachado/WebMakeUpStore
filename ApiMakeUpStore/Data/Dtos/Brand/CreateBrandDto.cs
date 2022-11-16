using System.ComponentModel.DataAnnotations;

namespace ApiMakeUpStore.Data.Dtos.Brand
{
    public class CreateBrandDto
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The country is required")]
        public string Country { get; set; }
    }
}
