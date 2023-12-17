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
    public class HomeDFService : IHomeService
    {
        public CarouselReceptViewModel GetHomeViewModel()
        {
            CarouselReceptViewModel viewModel = new CarouselReceptViewModel();

            viewModel.Recepts = DatabaseFake.Recepts;
            viewModel.Carousels = DatabaseFake.Carousels;

            return viewModel;
        }
    }
}
