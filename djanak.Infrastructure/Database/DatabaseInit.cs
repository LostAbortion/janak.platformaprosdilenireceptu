using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;

namespace djanak.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public IList<Product> GetProducts()
        {
            IList<Product> products = new List<Product>();


            products.Add(
                new Product()
                {
                    Id = 1,
                    Name = "Rohlík",
                    Description = "Nejlepší rohlík na světě",
                    Price = 10,
                    ImageSrc = "/img/products/produkt-01.jpg"
                });

            products.Add(
                new Product()
                {
                    Id = 2,
                    Name = "Chleba",
                    Description = "Nejlepší chleba ve vesmíru",
                    Price = 50,
                    ImageSrc = "/img/products/produkt-02.jpg"
                });

            products.Add(
                new Product()
                {
                    Id = 3,
                    Name = "Bageta",
                    Description = "Nejlepší bageta v galaxii",
                    Price = 35,
                    ImageSrc = "/img/products/produkt-03.jpg"
                });

            products.Add(
                new Product()
                {
                    Id = 4,
                    Name = "Dalamánek",
                    Description = "Nejlepší dalamánek ve sluneční soustavě",
                    Price = 8,
                    ImageSrc = "/img/products/produkt-04.jpg"
                });

            products.Add(
                new Product()
                {
                    Id = 5,
                    Name = "Vánočka",
                    Description = "Není to nic moc, ale může tady být",
                    Price = 80,
                    ImageSrc = "/img/products/produkt-05.jpg"
                });

            return products;
        }

        public IList<Carousel> GetCarousels()
        {
            IList<Carousel> carousels = new List<Carousel>();

            carousels.Add(new Carousel()
            {
                Id = 1,
                ImageSrc = "/img/carousel/carousel-01.jpg",
                ImageAlt = "First slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 2,
                ImageSrc = "/img/carousel/carousel-02.jpg",
                ImageAlt = "Second slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 3,
                ImageSrc = "/img/carousel/carousel-03.jpg",
                ImageAlt = "Third slide"
            });

            return carousels;
        }
    }
}
