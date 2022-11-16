namespace ApiMakeUpStore.Data.Dtos.Product
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdBrand { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string BodyPart { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string? Photo { get; set; }
    }
}
