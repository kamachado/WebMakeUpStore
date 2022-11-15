using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMakeUpStore.Models
{
    [Table("DEV_BRAND")]
    public class Brand
    {
        [Column("ID_BRAND")]
        public int Id { get; set; }

        [Column("NAME_BRAND")]
        public string Name { get; set; }

        [Column("COUNTRY_BRAND")]
        public string Country { get; set; }
    }
}
