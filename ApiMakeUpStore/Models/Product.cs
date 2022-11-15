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

        [Required]
        [Column("NAME_PRODUCT")]
        public string Name { get; set; }

        [Required]
        [Column("ID_Brand")]
        public int IdBrand { get; set; }

        [Required]
        [Column("DESCRIPTION_PRODUCT")]
        public string Description { get; set; }

        [Required]
        [Column("TYPE_PRODUCT")]
        public string Type { get; set; }

        [Column("BODYPART_PRODUCT")]
        public string BodyPart { get; set; }

        [Required]
        [Column("PRICE_PRODUCT")]
        public double Price { get; set; }

        [Required]
        [Column("QUANTITY_PRODUCT")]
        public int Quantity { get; set; }

        [Required]
        [Column("PHOTO_PRODUCT")]
        public string Photo { get; set; }

        [JsonIgnore]
        [ForeignKey("IdBrand")]
        public Brand? Brand { get; set; }



    }
}
