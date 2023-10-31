using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;

// TOTO JE STATICKÁ DATABÁZE KDE SE DEFINUJÍ S JAKÝMI LISTY DATABÁZE PRACUJE A INICIALIZUJE
// DATABASEINIT JE DALŠÍ SOUBOR, KDE JSOU PŘÍMO DO DATABÁZE UKLÁDÁNA REÁLNÁ DATA
namespace djanak.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Product> Products { get; set; }
        public static List<Carousel> Carousels { get; set; }
        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();
            Products = dbInit.GetProducts().ToList();
            Carousels = dbInit.GetCarousels().ToList();
        }
    }
}
