using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
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

        public void Create(Product product)
        {
            if (DatabaseFake.Products != null && DatabaseFake.Products.Count < 0)
            {
                product.Id = DatabaseFake.Products.Last().Id + 1;
            }
            else
            {
                product.Id = 1;
            }

            if (DatabaseFake.Products != null)
            {
                DatabaseFake.Products.Add(product);
            }

            public bool Delete(int id) 
            {
                bool deleted = false;

                Product? product = DatabaseFake.Products.FirstOrDefault(product => product.Id == id);

                if (product != null)
                {
                    deleted = DatabaseFake.Products.Remove(product);
                }

                return deleted;
            }
        }
    }
}
