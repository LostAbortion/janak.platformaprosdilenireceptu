using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;


// ZDE SE ASI NĚJAKÝM ZPŮSOBEM JENOM DEFINUJE CO DANÝ PROJEKT//IRECEPTADMINSERVICE UMÍ
namespace djanak.Application.Abstraction
{
    public interface IReceptAdminService
    {
        IList<Recept> Select();
        Task Create(Recept recept);
        bool Delete(int id);
        Task Edit(Recept recept);
        Recept GetReceptById(int id);
    }
}
