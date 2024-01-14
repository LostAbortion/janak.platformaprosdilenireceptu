using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Application.Abstraction;
using djanak.Application.ViewModels;
using djanak.Domain.Entities;
using djanak.Infrastructure.Database;
using System.Drawing;
using System.IO;

namespace djanak.Application.Implementation
{
    public class ReceptAdminService : IReceptAdminService
    {
        IFileUploadService _fileUploadService;
        PortalDbContext _portalDbContext;

        public ReceptAdminService(IFileUploadService fileUploadService, PortalDbContext portalDbContext)
        {
            _fileUploadService = fileUploadService;
            _portalDbContext = portalDbContext;
        }

        public IList<Recept> Select()
        {
            return _portalDbContext.Recepts.ToList();
        }

        public async Task Create(Recept recept)
        {
            string imageSource = await _fileUploadService.FileUploadAsync(recept.Image, Path.Combine("img", "products"));
            recept.ImageSrc = imageSource;

            if (_portalDbContext.Recepts != null)
            {
                _portalDbContext.Recepts.Add(recept);
                _portalDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Recept? product = _portalDbContext.Recepts.FirstOrDefault(product => product.Id == id);

            if (product != null)
            {
                _portalDbContext.Recepts.Remove(product);
                _portalDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public async Task Edit(ReceptViewModel receptViewModel)  //toto je pouze jenom jako dummy metoda proto abych mohl provést migraci
        {
            //ReceptViewModel receptToUpdate = MapReceptToViewModel(recept);  //Použití metody pro mapování ViewModelu na entitu
            Recept currentRecept = _portalDbContext.Recepts.FirstOrDefault(p => p.Id == receptViewModel.Id);

            if (currentRecept != null)
            {
                //Zde změní hodnoty aktuálního produktu na nové
                currentRecept.NazevReceptu = receptViewModel.Nazev;
                currentRecept.PopisReceptu = receptViewModel.Popis;
                currentRecept.Kategorie = receptViewModel.Kategorie;
                currentRecept.Obtiznost = receptViewModel.Obtiznost;
                currentRecept.CasovaNarocnost = receptViewModel.CasovaNarocnost;
                currentRecept.SeznamSurovin = receptViewModel.SeznamSurovin;
                currentRecept.PostupPripravy = receptViewModel.PostupPripravy;
                currentRecept.DatumVytvoreni = receptViewModel.DatumVytvoreni;
                //currentRecept.ImageSrc = receptViewModel.ImageSrc;
                //currentRecept.Image = receptViewModel.Image;
            }

            // Aktualizace vlastností aktuálního receptu na základě dat z upraveného receptu
            //_portalDbContext.Entry(currentRecept).CurrentValues.SetValues(receptToUpdate);


            // Provádí aktualizaci vlastností aktuálního receptu na základě dat z upraveného receptu
            //_portalDbContext.Update(currentRecept);





            if (currentRecept.Image != null)
            {
                // Případná změna obrázku - tady provedeš práci s obrázkem, pokud uživatel změnil obrázek
                string newImageSource = await _fileUploadService.FileUploadAsync(currentRecept.Image, Path.Combine("img", "products"));
                currentRecept.ImageSrc = newImageSource;
            }

            _portalDbContext.SaveChanges(); // Uložení změn do databáze
        }

        public Recept GetReceptById(int id)  //toto je dummy metoda, která když se zavolá tak vyhodí chybu
                                               //mám ji tu proto aby mě visual studio nechalo provést migraci na databázi
        {
            return _portalDbContext.Recepts.FirstOrDefault(p => p.Id == id);  
        }


        //MAPOVÁNÍ RECEPTVIEWMODELU NA ENTITU RECEPT
        public ReceptViewModel MapReceptToViewModel(Recept entity)
        {
            return new ReceptViewModel
            {
                Nazev = entity.NazevReceptu,
                Popis = entity.PopisReceptu,
                Kategorie = entity.Kategorie,
                Obtiznost = entity.Obtiznost,
                CasovaNarocnost = entity.CasovaNarocnost,
                SeznamSurovin = entity.SeznamSurovin,
                PostupPripravy = entity.PostupPripravy,
                DatumVytvoreni = entity.DatumVytvoreni,
                ImageSrc = entity.ImageSrc,
                Image = entity.Image
                // Zde nebudeme mapovat Image, protože ViewModel má jiný typ pro obrázek
            };
        }

        public Recept MapViewModelToRecept(ReceptViewModel viewModel)
        {
            return new Recept
            {
                NazevReceptu = viewModel.Nazev,
                PopisReceptu = viewModel.Popis,
                Kategorie = viewModel.Kategorie,
                Obtiznost = viewModel.Obtiznost,
                CasovaNarocnost = viewModel.CasovaNarocnost,
                SeznamSurovin = viewModel.SeznamSurovin,
                PostupPripravy = viewModel.PostupPripravy,
                DatumVytvoreni = viewModel.DatumVytvoreni,
                ImageSrc = viewModel.ImageSrc,
                Image = viewModel.Image
                // Zde budeme potřebovat převést Image z byte[] na IFormFile, pokud se bude chtít editovat
            };
        }
    }
}
