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
                    NazevProductu = "Pražská polévka",
                    Kategorie = "Oběd",
                    Obtiznost = "Snadné",
                    CasovaNarocnost = "30 minut",
                    PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                    SeznamSurovin = "1ks cibule, 1ks mrkev, 2ks brambory, 1ks klobása, 1l vývar, sůl, 2 lžičky sladké papriky, 1 lžíce sádla",
                    PostupPripravy = "Nakrájenou cibuli necháme 12 minut odležet. Poté ji na sádle zpěníme, přidáme nakrájenou klobásu a opečeme." +
                    "Přidáme mrkev, orestujeme a poté zasypeme červenou paprikou. Vše zalijeme vývarem, přidáme oloupané, nakrájené brambory, osolíme a polévku vaříme 15 minut.",
                    DatumVytvoreni = new DateTime(2023, 10, 31),
                    ImageSrc = "/img/products/recept_01.jpg",
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
                ImageSrc = "/img/carousel/carousel_01.jpg",
                ImageAlt = "First slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 2,
                ImageSrc = "/img/carousel/carousel_02.jpg",
                ImageAlt = "Second slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 3,
                ImageSrc = "/img/carousel/carousel_03.jpg",
                ImageAlt = "Third slide"
            });

            return carousels;
        }
    }
}
