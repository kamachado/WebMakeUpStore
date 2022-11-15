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

        [Required]
        [Column("NAME_BRAND")]
        public string Name { get; set; }
       
        [Required]
        [Column("COUNTRY_BRAND")]
        public string Country { get; set; }
    }
}
