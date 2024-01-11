using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Application.ViewModels;
using djanak.Domain.Entities;
using System.Drawing;
using System.IO;


// ZDE SE ASI NĚJAKÝM ZPŮSOBEM JENOM DEFINUJE CO DANÝ PROJEKT//IRECEPTADMINSERVICE UMÍ
namespace djanak.Application.Abstraction
{
    public interface IReceptAdminService
    {
        IList<Recept> Select();
        Task Create(Recept recept);
        bool Delete(int id);
        Task Edit(ReceptViewModel receptViewModel);
        Recept GetReceptById(int id);

        ReceptViewModel MapReceptToViewModel(Recept recept);
        Recept MapViewModelToRecept(ReceptViewModel viewModel);
    }
}
