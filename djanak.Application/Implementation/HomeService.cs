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
        PortalDbContext _portalDbContext;
        public HomeService(PortalDbContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }
        public CarouselReceptViewModel GetHomeViewModel()
        {
            CarouselReceptViewModel viewModel = new CarouselReceptViewModel();

            viewModel.Recepts = _portalDbContext.Recepts.ToList();
            viewModel.Carousels = _portalDbContext.Carousels.ToList();

            return viewModel;
        }
    }
}
