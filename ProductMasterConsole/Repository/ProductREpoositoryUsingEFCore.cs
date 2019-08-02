using System.Linq;
using ProductMasterConsole.Model;

namespace ProductMasterConsole.Repository
{
    public class ProductREpoositoryUsingEFCore
    {
        public Product[] AllProducts()
            => new eftipsContext().Product.ToArray();
    }
}