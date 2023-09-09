using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category();
           // DAL dAL = new DAL();
            ProductService productService = new ProductService();
            // category.ReadbyID(1);
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
            productService.ReadbyName("aloe");

        }

    }
}
