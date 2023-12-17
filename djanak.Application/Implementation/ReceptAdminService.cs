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
    public class ReceptAdminService : IReceptAdminService
    {
        IFileUploadService _fileUploadService;
        EshopDbContext _eshopDbContext;

        public ReceptAdminService(IFileUploadService fileUploadService, EshopDbContext eshopDbContext)
        {
            _fileUploadService = fileUploadService;
            _eshopDbContext = eshopDbContext;
        }

        public IList<Recept> Select()
        {
            return _eshopDbContext.Recepts.ToList();
        }

        public async Task Create(Recept product)
        {
            string imageSource = await _fileUploadService.FileUploadAsync(product.Image, Path.Combine("img", "products"));
            product.ImageSrc = imageSource;

            if (_eshopDbContext.Recepts != null)
            {
                _eshopDbContext.Recepts.Add(product);
                _eshopDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Recept? product = _eshopDbContext.Recepts.FirstOrDefault(product => product.Id == id);

            if (product != null)
            {
                _eshopDbContext.Recepts.Remove(product);
                _eshopDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public async Task Edit(Recept product)  //toto je pouze jenom jako dummy metoda proto abych mohl provést migraci
        {
            Recept currentProduct = _eshopDbContext.Recepts.FirstOrDefault(p => p.Id == product.Id);

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


                _eshopDbContext.SaveChanges();

                if (product.Image != null)
                {
                    string newImageSource = await _fileUploadService.FileUploadAsync(product.Image, Path.Combine("img", "products"));
                    currentProduct.ImageSrc = newImageSource;
                }

                _eshopDbContext.SaveChanges(); // Uložení změn do databáze
            }
        }

        public Recept GetReceptById(int id)  //toto je dummy metoda, která když se zavolá tak vyhodí chybu
                                               //mám ji tu proto aby mě visual studio nechalo provést migraci na databázi
        {
            return _eshopDbContext.Recepts.FirstOrDefault(p => p.Id == id);  
        }
    }
}
