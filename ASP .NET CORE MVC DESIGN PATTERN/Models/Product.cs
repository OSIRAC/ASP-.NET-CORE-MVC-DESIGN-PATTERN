namespace EFCORE_VERİALMA.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }

        public string? Colour { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsPublish { get; set; }

        public int Expire { get; set; }
    }
}
