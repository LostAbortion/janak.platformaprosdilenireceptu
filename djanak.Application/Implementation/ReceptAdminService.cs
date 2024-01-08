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

        public async Task Create(Recept recept)
        {
            string imageSource = await _fileUploadService.FileUploadAsync(recept.Image, Path.Combine("img", "products"));
            recept.ImageSrc = imageSource;

            if (_eshopDbContext.Recepts != null)
            {
                _eshopDbContext.Recepts.Add(recept);
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

        public async Task Edit(Recept recept)  //toto je pouze jenom jako dummy metoda proto abych mohl provést migraci
        {
            Recept currentRecept = _eshopDbContext.Recepts.FirstOrDefault(p => p.Id == recept.Id);

            if (currentRecept != null)
            {

                // Provádí aktualizaci vlastností aktuálního receptu na základě dat z upraveného receptu
                _eshopDbContext.Update(currentRecept);


                //Zde změní hodnoty aktuálního produktu na nové
                //currentRecept.NazevProductu = recept.NazevProductu;
                //currentRecept.Kategorie = recept.Kategorie;
                //currentRecept.Obtiznost = recept.Obtiznost;
                //currentRecept.CasovaNarocnost = recept.CasovaNarocnost;
                //currentRecept.PopisReceptu = recept.PopisReceptu;
                //currentRecept.SeznamSurovin = recept.SeznamSurovin;
                //currentRecept.PostupPripravy = recept.PostupPripravy;
                //currentRecept.DatumVytvoreni = recept.DatumVytvoreni;
                //currentRecept.ImageSrc = recept.ImageSrc;


                _eshopDbContext.SaveChanges();

                if (recept.Image != null)
                {
                    string newImageSource = await _fileUploadService.FileUploadAsync(recept.Image, Path.Combine("img", "products"));
                    currentRecept.ImageSrc = newImageSource;
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
