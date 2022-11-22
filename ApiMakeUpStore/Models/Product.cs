using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiMakeUpStore.Models
{

    public class Product
    {
        [Key]
        [Required]
        [Column("ID_PRODUCT")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [Column("NAME_PRODUCT")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Id of Brand is required")]
        [Column("ID_Brand")]
        public int IdBrand { get; set; }


        [Column("DESCRIPTION_PRODUCT")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The type is required")]
        [Column("TYPE_PRODUCT")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The body part is required")]
        [Column("BODYPART_PRODUCT")]
        public string BodyPart { get; set; }

        [Required(ErrorMessage = "The price is required")]
        [Column("PRICE_PRODUCT")]
        [Range(0.01,100000000000, ErrorMessage = "the price can't be less than 0.01")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The quantity is required")]
        [Column("QUANTITY_PRODUCT")]
        public int Quantity { get; set; }

        [JsonIgnore]
        [ForeignKey("IdBrand")]
        public Brand? Brand { get; set; }



    }
}
