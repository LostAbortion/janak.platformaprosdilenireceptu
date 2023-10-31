using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using djanak.Application.Abstraction;
using djanak.Domain.Entities;
using djanak.Infrastructure.Database;

// ZDE SE ACTUALLY PRACUJE S PŘIJATÝMI PŘÍKAZY OD CLIENTA JAKO JE CREATE, DELETE, EDIT
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
            if (DatabaseFake.Products != null && DatabaseFake.Products.Count > 0)
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

        public void Edit(Product product)
        {
            Product currentProduct = DatabaseFake.Products.FirstOrDefault(p => p.Id == product.Id);

            if (currentProduct != null) 
            {
                //Zde změní hodnoty aktuálního produktu na nové
                currentProduct.Name = product.Name;
                currentProduct.Description = product.Description;
                currentProduct.Price = product.Price;
                currentProduct.ImageSrc = product.ImageSrc;
            }
        }

        public Product GetProductById(int id)
        {
            return DatabaseFake.Products.FirstOrDefault(prod => prod.Id == id);
        }
    }
}
