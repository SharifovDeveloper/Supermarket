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
            DAL dal = new DAL();
            dal.CreateProduct("Fanta",1200);
            dal.ReadAllProducts();
        }
    }
}
