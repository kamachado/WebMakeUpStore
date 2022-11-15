using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiMakeUpStore.Models
{

    [Table("DEV_PRODUCT")]
    public class Product
    {
        [Column("ID_PRODUCT")]
        public int Id { get; set; }

        [Column("NAME_PRODUCT")]
        public string Name { get; set; }

        [Column("ID_Brand")]
        public int IdBrand { get; set; }

        [Column("DESCRIPTION_PRODUCT")]
        public string Description { get; set; }

        [Column("TYPE_PRODUCT")]
        public string Type { get; set; }

        [Column("BODYPART_PRODUCT")]
        public string BodyPart { get; set; }

        [Column("PRICE_PRODUCT")]
        public double Price { get; set; }

        [Column("PHOTO_PRODUCT")]
        public string Photo { get; set; }

        [JsonIgnore]
        [ForeignKey("IdBrand")]
        public Brand? Brand { get; set; }

    }
}
