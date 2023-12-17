using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;


// ZDE SE ASI NĚJAKÝM ZPŮSOBEM JENOM DEFINUJE CO DANÝ PROJEKT//IPRODUCTADMINSERVICE UMÍ
namespace djanak.Application.Abstraction
{
    public interface IProductAdminService
    {
        IList<Recept> Select();
        Task Create(Recept product);
        bool Delete(int id);
        Task Edit(Recept product);
        Recept GetProductById(int id);
    }
}
