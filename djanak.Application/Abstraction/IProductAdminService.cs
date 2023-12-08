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
        IList<Product> Select();
        Task Create(Product product);
        bool Delete(int id);
        void Edit(Product product);
        //Product GetProductById(int id);
    }
}
