using djanak.Domain.Entities;
using djanak.Domain.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace djanak.Application.ViewModels
{
    public class ReceptViewModel : Entity
    {

        [Required]
        [StringLength(100)]
        public string Nazev { get; set; }

        public string Popis { get; set; }

        [Required]
        public string Kategorie { get; set; }

        public string Obtiznost { get; set; }
        public string CasovaNarocnost { get; set; }
        public string SeznamSurovin { get; set; }

        [Required]
        public string PostupPripravy { get; set; }

        public DateTime DatumVytvoreni { get; set; }

        public string ImageSrc { get; set; }

        [NotMapped] // -> Toto myslím vysvětlovat tak že SQL není schopná přijmout adresu obrázku nebo tak něco. A tohle z toho prostě udělá nějakou
                    // bitovou řadu a pak to pujde
        [FileContent("image")]
        public IFormFile Image { get; set; } // Byte pole pro ukládání dat souboru

        public ReceptViewModel() { } // Prázdný konstruktor pro potřeby model bindingu

        public ReceptViewModel(Recept recept)
        {
            Nazev = recept.NazevReceptu;
            Popis = recept.PopisReceptu;
            Kategorie = recept.Kategorie;
            Obtiznost = recept.Obtiznost;
            CasovaNarocnost = recept.CasovaNarocnost;
            SeznamSurovin = recept.SeznamSurovin;
            PostupPripravy = recept.PostupPripravy;
            DatumVytvoreni = recept.DatumVytvoreni;
            ImageSrc = recept.ImageSrc;
            Image = recept.Image;
            // Není zahrnuto mapování pro Image, protože to bude uloženo v byte[] formátu
        }
    }
}
