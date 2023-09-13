namespace Supermarket.Models
{
    public class Product
    {
        public Product(int id, string productName, decimal price, int categoryId)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
