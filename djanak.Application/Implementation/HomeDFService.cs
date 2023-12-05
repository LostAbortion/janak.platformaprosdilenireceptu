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
        public CarouselProductViewModel GetHomeViewModel()
        {
            CarouselProductViewModel viewModel = new CarouselProductViewModel();

            viewModel.Products = DatabaseFake.Products;
            viewModel.Carousels = DatabaseFake.Carousels;

            return viewModel;
        }
    }
}
