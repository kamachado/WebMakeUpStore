using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMakeUpStore.Models
{
    public class Brand
    {
        [Key]
        [Required]
        [Column("ID_BRAND")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [Column("NAME_BRAND")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The country is required")]
        [Column("COUNTRY_BRAND")]
        public string Country { get; set; }
    }
}
