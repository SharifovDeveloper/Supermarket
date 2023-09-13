namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoryDbService category = new CategoryDbService();
            // DAL dAL = new DAL();
            ProductDbService productService = new ProductDbService();
            //     category.ReadAllCategory();
            category.ReadbyID(2);
            
            // category.UpdateCategory(4, "Fruits");
            // category.ReadAllCategory();
            // category.DeleteCategory(3);
            //  category.ReadbyName("bavarages");

            //  dAL.ReadbyPrice(500);

            //productService.CreateProduct("Aloe", 11000, 1);
            // productService.ReadAllProducts();
            //productService.ReadAllProducts();
            // productService.ReadAllProducts();
            //  productService.GetProductsByCategoryId(1);
            //category.ReadbyCountProducts(2);
            // productService.ReadbyPrice(10000);
          //  productService.ReadbyName("aloe");

        }

    }
}
