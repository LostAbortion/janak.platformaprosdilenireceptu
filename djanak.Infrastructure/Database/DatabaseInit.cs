using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;

// ZDE SE PŘÍMO INICIALIZUJE DATABÁZE
// DO ILIST<PRODUCT> SE PŘIDÁVAJÍ DATA
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
                    NazevProductu = "Svíčková s falešnou svíčkovou1",
                    Kategorie = "Omáčky",
                    Obtiznost = "Střední",
                    CasovaNarocnost = "Do hodiny",
                    PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                    SeznamSurovin = "maso, všechno další",
                    PostupPripravy = "Prvně nasekat, pak promíchat, pak povařit",
                    DatumVytvoreni = new DateTime(2022, 12, 12),
                    ImageSrc = "/img/products/produkt-01.jpg",
                    ImageAlt = "Obrazek1"
                });
            
            products.Add(
                new Product()
                {
                    Id = 2,
                    NazevProductu = "Svíčková s falešnou svíčkovou2",
                    Kategorie = "Omáčky",
                    Obtiznost = "Střední",
                    CasovaNarocnost = "Do hodiny",
                    PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                    SeznamSurovin = "maso, všechno další",
                    PostupPripravy = "Prvně nasekat, pak promíchat, pak povařit",
                    DatumVytvoreni = new DateTime(2022, 12, 12),
                    ImageSrc = "/img/products/produkt-01.jpg",
                    ImageAlt = "Obrazek2"
                });

            products.Add(
                new Product()
                {
                    Id = 3,
                    NazevProductu = "Svíčková s falešnou svíčkovou3",
                    Kategorie = "Omáčky",
                    Obtiznost = "Střední",
                    CasovaNarocnost = "Do hodiny",
                    PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                    SeznamSurovin = "maso, všechno další",
                    PostupPripravy = "Prvně nasekat, pak promíchat, pak povařit",
                    DatumVytvoreni = new DateTime(2022, 12, 12),
                    ImageSrc = "/img/products/produkt-01.jpg",
                    ImageAlt = "Obrazek1"
                });

            products.Add(
                new Product()
                {
                    Id = 4,
                    NazevProductu = "Svíčková s falešnou svíčkovou4",
                    Kategorie = "Omáčky",
                    Obtiznost = "Střední",
                    CasovaNarocnost = "Do hodiny",
                    PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                    SeznamSurovin = "maso, všechno další",
                    PostupPripravy = "Prvně nasekat, pak promíchat, pak povařit",
                    DatumVytvoreni = new DateTime(2022, 12, 12),
                    ImageSrc = "/img/products/produkt-01.jpg",
                    ImageAlt = "Obrazek1"
                });

            products.Add(
                new Product()
                {
                    Id = 5,
                    NazevProductu = "Svíčková s falešnou svíčkovou5",
                    Kategorie = "Omáčky",
                    Obtiznost = "Střední",
                    CasovaNarocnost = "Do hodiny",
                    PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                    SeznamSurovin = "maso, všechno další",
                    PostupPripravy = "Prvně nasekat, pak promíchat, pak povařit",
                    DatumVytvoreni = new DateTime(2022, 12, 12),
                    ImageSrc = "/img/products/produkt-01.jpg",
                    ImageAlt = "Obrazek1"
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
