using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;

namespace djanak.Application.Abstraction
{
    public interface IProductAdminService
    {
        IList<Product> Select();
    }
}
