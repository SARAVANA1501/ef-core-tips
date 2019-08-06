using System.Collections.Generic;
using System.Linq;
using ProductMasterConsole.Model;

namespace ProductMasterConsole.Repository
{
    public class ProductRetrievalUsingIQueryable
    {
        public IQueryable<Product> ProductByNameLike(string name)
            => new eftipsContext().Product.Where(t=>t.ProductName.Contains(name));

        public int Count(string name) => this.ProductByNameLike(name).Count();
    }
}

//Call the count method will execute following command against DB:
//SELECT count(*)::INT
//FROM product AS t
//WHERE STRPOS(t."ProductName", @__name_0) > 0
