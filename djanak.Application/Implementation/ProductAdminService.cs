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
    public class ProductAdminService : IProductAdminService
    {
        IFileUploadService _fileUploadService;
        EshopDbContext _eshopDbContext;

        public ProductAdminService(IFileUploadService fileUploadService, EshopDbContext eshopDbContext)
        {
            _fileUploadService = fileUploadService;
            _eshopDbContext = eshopDbContext;
        }

        public IList<Product> Select()
        {
            return _eshopDbContext.Products.ToList();
        }

        public async Task Create(Product product)
        {
            string imageSource = await _fileUploadService.FileUploadAsync(product.Image, Path.Combine("img", "products"));
            product.ImageSrc = imageSource;

            if (_eshopDbContext.Products != null)
            {
                _eshopDbContext.Products.Add(product);
                _eshopDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Product? product = _eshopDbContext.Products.FirstOrDefault(product => product.Id == id);

            if (product != null)
            {
                _eshopDbContext.Products.Remove(product);
                _eshopDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public void Edit(Product product)
        {
            // Implementace logiky pro editaci produktu
        }
    }
}
