using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;

namespace djanak.Application.ViewModels
{
    public class CarouselProductViewModel
    {
        public IList<Carousel> Carousels {  get; set; }
        public IList<Recept> Products { get; set; }
    }
}
