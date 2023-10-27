using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Application.Abstraction;
using djanak.Domain.Entities;
using djanak.Infrastructure.Database;

namespace djanak.Application.Implementation
{
    public class ProductAdminDFakeService : IProductAdminService
    {
        public IList<Product> Select()
        {
            return DatabaseFake.Products;
        }
    }
}
