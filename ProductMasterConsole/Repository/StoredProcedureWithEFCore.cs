using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductMasterConsole.Model;

namespace ProductMasterConsole.Repository
{
    public class StoredProcedureWithEFCore
    {
        public CustomModelForSP[] GetProductName()
        {
            var context = new eftipsContext();
            return context.ProductNames.FromSql("select * from  get_productnames()").ToArray();
        }
    }
}