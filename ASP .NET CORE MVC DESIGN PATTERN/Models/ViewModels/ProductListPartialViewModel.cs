using System.Reflection.Metadata.Ecma335;

namespace EFCORE_VERİALMA.Models.ViewModels
{
    public class ProductListPartialViewModel
    {
        public List<ProductPartialViewModel> Products { get; set; }

    }

    public class ProductPartialViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }
    }
}
