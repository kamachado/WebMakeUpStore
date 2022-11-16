using System.ComponentModel.DataAnnotations;

namespace ApiMakeUpStore.Data.Dtos.Product
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Id of Brand is required")]
        public int IdBrand { get; set; }

        [Required(ErrorMessage = "The description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The body part is required")]
        public string BodyPart { get; set; }

        [Required(ErrorMessage = "The price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The quantity is required")]
        public int Quantity { get; set; }


        
    }
}
