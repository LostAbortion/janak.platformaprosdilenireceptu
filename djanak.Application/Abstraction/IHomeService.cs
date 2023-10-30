using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Application.ViewModels;

namespace djanak.Application.Abstraction
{
    public interface IHomeService
    {
        CarouselProductViewModel GetHomeViewModel();
    }
}
