using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using djanak.Application.Abstraction;
using djanak.Application.ViewModels;
using djanak.Domain.Entities;
using djanak.Infrastructure.Database;

// ZDE SE ACTUALLY PRACUJE S PŘIJATÝMI PŘÍKAZY OD CLIENTA JAKO JE CREATE, DELETE, EDIT
namespace djanak.Application.Implementation
{
    public class ProductAdminDFakeService : IReceptAdminService
    {
        IFileUploadService _fileUploadService;  //fileUpload service na přijimání souborů

        public ProductAdminDFakeService(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public IList<Recept> Select()
        {
            return DatabaseFake.Recepts;
        }

        public async Task Create(Recept recept)  //z create metody jsme udělali async. Kvůli uploadu našeho souboru
        {
            if (DatabaseFake.Recepts != null && DatabaseFake.Recepts.Count > 0)
            {
                recept.Id = DatabaseFake.Recepts.Last().Id + 1;
            }
            else
            {
                recept.Id = 1;
            }

            string imageSource = await _fileUploadService.FileUploadAsync(recept.Image, Path.Combine("img", "products"));
            recept.ImageSrc = imageSource;

            if (DatabaseFake.Recepts != null)
            {
                DatabaseFake.Recepts.Add(recept);
            }
        }
        public bool Delete(int id)
        {
            bool deleted = false;

            Recept? recept = DatabaseFake.Recepts.FirstOrDefault(recept => recept.Id == id);

            if (recept != null)
            {
                deleted = DatabaseFake.Recepts.Remove(recept);
            }

            return deleted;
        }

        public void Edit(Recept recept)  //změnil jsem název funkce aby přestala fungovat když ji budu volat a zprovoznil jsem tak edit na reálné databázi
        {
            Recept currentProduct = DatabaseFake.Recepts.FirstOrDefault(p => p.Id == recept.Id);

            if (currentProduct != null)
            {
                //Zde změní hodnoty aktuálního produktu na nové
                currentProduct.NazevProductu = recept.NazevProductu;
                currentProduct.Kategorie = recept.Kategorie;
                currentProduct.Obtiznost = recept.Obtiznost;
                currentProduct.CasovaNarocnost = recept.CasovaNarocnost;
                currentProduct.PopisReceptu = recept.PopisReceptu;
                currentProduct.SeznamSurovin = recept.SeznamSurovin;
                currentProduct.PostupPripravy = recept.PostupPripravy;
                currentProduct.DatumVytvoreni = recept.DatumVytvoreni;
                currentProduct.ImageSrc = recept.ImageSrc;
            }
        }

        public Recept GetReceptById(int id)
        {
            return DatabaseFake.Recepts.FirstOrDefault(prod => prod.Id == id);
        }

        public Task Edit(ReceptViewModel recept)
        {
            throw new NotImplementedException();
        }

        public ReceptViewModel MapReceptToViewModel(Recept recept)
        {
            throw new NotImplementedException();
        }

        public Recept MapViewModelToRecept(ReceptViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        Task IReceptAdminService.Edit(ReceptViewModel receptViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
