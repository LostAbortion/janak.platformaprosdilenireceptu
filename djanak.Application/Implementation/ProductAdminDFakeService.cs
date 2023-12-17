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
        IFileUploadService _fileUploadService;  //fileUpload service na přijimání souborů

        public ProductAdminDFakeService(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public IList<Recept> Select()
        {
            return DatabaseFake.Products;
        }

        public async Task Create(Recept product)  //z create metody jsme udělali async. Kvůli uploadu našeho souboru
        {
            if (DatabaseFake.Products != null && DatabaseFake.Products.Count > 0)
            {
                product.Id = DatabaseFake.Products.Last().Id + 1;
            }
            else
            {
                product.Id = 1;
            }

            string imageSource = await _fileUploadService.FileUploadAsync(product.Image, Path.Combine("img", "products"));
            product.ImageSrc = imageSource;

            if (DatabaseFake.Products != null)
            {
                DatabaseFake.Products.Add(product);
            }
        }
        public bool Delete(int id)
        {
            bool deleted = false;

            Recept? product = DatabaseFake.Products.FirstOrDefault(product => product.Id == id);

            if (product != null)
            {
                deleted = DatabaseFake.Products.Remove(product);
            }

            return deleted;
        }

        public async Task Edit(Recept product)  //změnil jsem název funkce aby přestala fungovat když ji budu volat a zprovoznil jsem tak edit na reálné databázi
        {
            Recept currentProduct = DatabaseFake.Products.FirstOrDefault(p => p.Id == product.Id);

            if (currentProduct != null)
            {
                //Zde změní hodnoty aktuálního produktu na nové
                currentProduct.NazevProductu = product.NazevProductu;
                currentProduct.Kategorie = product.Kategorie;
                currentProduct.Obtiznost = product.Obtiznost;
                currentProduct.CasovaNarocnost = product.CasovaNarocnost;
                currentProduct.PopisReceptu = product.PopisReceptu;
                currentProduct.SeznamSurovin = product.SeznamSurovin;
                currentProduct.PostupPripravy = product.PostupPripravy;
                currentProduct.DatumVytvoreni = product.DatumVytvoreni;
                currentProduct.ImageSrc = product.ImageSrc;
                currentProduct.ImageAlt = product.ImageAlt;
            }
        }

        public Recept GetProductById(int id)
        {
            return DatabaseFake.Products.FirstOrDefault(prod => prod.Id == id);
        }
    }
}
