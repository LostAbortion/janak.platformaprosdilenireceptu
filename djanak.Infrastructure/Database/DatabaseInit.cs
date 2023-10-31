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
                    NazevProductu = "Vařené brambory",
                    Kategorie = "Přílohy",
                    Obtiznost = "Snadné",
                    CasovaNarocnost = "40 minut",
                    PopisReceptu = "Brambory se hodí ke všemu",
                    SeznamSurovin = "6ks brambory, 1 špetka soli, 1 špetka kmínu",
                    PostupPripravy = "Brambory oloupeme a dáme do hrnce s vodou." +
                    "Nakrájíme je na kostky, propláchneme a zalijeme čerstvou vodou. Osolíme, přidáme kmín a dáme vařit." +
                    "Vaříme 15 minut do změknutí. Zda jsou brambory hotové, poznáme tak, že se po píchnutí vidličkou rozpadnou.",
                    DatumVytvoreni = new DateTime(2020, 10, 31),
                    ImageSrc = "/img/products/recept_02.jpg",
                    ImageAlt = "Obrazek2"
                });

            products.Add(
                new Product()
                {
                    Id = 3,
                    NazevProductu = "Tuňákové těstoviny",
                    Kategorie = "Oběd",
                    Obtiznost = "Snadné",
                    CasovaNarocnost = "20 minut",
                    PopisReceptu = "Tuňák je zdravý pro kosti (určitě jo)",
                    SeznamSurovin = "1ks cibule, olivový olej, 3 stoužky česneku, 1 plechovka loupaných rajčat, pepř, sůl, 180g tuňáka v plechu, strouhaný parmazám," +
                    "200g těstovin",
                    PostupPripravy = "Těstoviny uvaříme dle návodu." +
                    "Na troše olivového oleje necháme zesklovatět nadrobno nakrájenou cibuli. Přidáme na plátky nakrájený česnek, chvilku míchejte." +
                    "Přidejte rajčata a nakrájené lístky bazalky. Chvíli povařte. Nakonec vmíchejte rozdrobené maso tuňáka," +
                    "které se snažíme vložit do jídla s minimálním množstvím oleje z konzervy, dochuťte solí/pepřem a nechte maso ve směsi prohřát." +
                    "Do hotové směsi vmíchejte těstoviny a můžete servírovat. V případě zájmu je možné těstoviny posypat strouhaným parmazánem, není to však třeba.",
                    DatumVytvoreni = new DateTime(2023, 1, 1),
                    ImageSrc = "/img/products/recept_03.jpg",
                    ImageAlt = "Obrazek3"
                });

            products.Add(
                new Product()
                {
                    Id = 4,
                    NazevProductu = "Kuřecí prsa s broskvemi a švestkami",
                    Kategorie = "Oběd",
                    Obtiznost = "Střední",
                    CasovaNarocnost = "40 minut",
                    PopisReceptu = "Mňam mňam broskvička s masíkem",
                    SeznamSurovin = "4ks kuřecí prsa, 2 lžíce povidla, 8 plátků šunky, 8ks šarlotky, 8ks švestek, 2ks broskve, olivový olej, sůl, pepř",
                    PostupPripravy = "Prvně nasekat, pak povařit, pak promíchat. Tenhle recept je hrozně dlouhej, tak jsem ho sem nevkládal celej.",
                    DatumVytvoreni = new DateTime(2023, 10, 31),
                    ImageSrc = "/img/products/recept_04.jpg",
                    ImageAlt = "Obrazek4"
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
