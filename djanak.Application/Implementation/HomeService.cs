using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Application.Abstraction;
using djanak.Application.ViewModels;
using djanak.Infrastructure.Database;

namespace djanak.Application.Implementation
{
    public class HomeService : IHomeService
    {
        EshopDbContext _eshopDbContext;
        public HomeService(EshopDbContext eshopDbContext)
        {
            _eshopDbContext = eshopDbContext;
        }
        public CarouselProductViewModel GetHomeViewModel()
        {
            CarouselProductViewModel viewModel = new CarouselProductViewModel();

            viewModel.Products = _eshopDbContext.Products.ToList();
            viewModel.Carousels = _eshopDbContext.Carousels.ToList();

            return viewModel;
        }
    }
}
