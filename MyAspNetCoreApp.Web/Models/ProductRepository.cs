namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {

        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "ARABA", Stock = 12, Price = 24 },
            new () { Id = 2, Name = "KARS", Stock = 21, Price = 45 },
            new (){ Id = 3, Name = "ODA", Stock = 34, Price = 67 }
        };

        public List<Product> ListProducts() => _products;

        public void NewProduct(Product product) => _products.Add(product);

        public void RemoveProduct(int id)
        {
            var hasproduct = _products.FirstOrDefault(p => p.Id == id); 

            if(hasproduct != null)
            {
                _products.Remove(hasproduct);
            }
            else
            {
                throw new InvalidOperationException($"BU {id} YE SAHİP ÜRÜN YOK");
            }

        }

        public void UpdateProduct(Product product)
        {
            var hasproduct = _products.FirstOrDefault(x => x.Id == product.Id);

            if (hasproduct != null)
            {
                hasproduct.Name = product.Name;
                hasproduct.Price = product.Price;
                hasproduct.Stock = product.Stock;
            }
            else
            {
                throw new InvalidOperationException($"BU {product.Id} YE SAHİP ÜRÜN YOK");
            }    
        }


    }
}
