using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using djanak.Domain.Validations;

namespace djanak.Domain.Entities
{
    public class Recept : Entity  //bývalý Product.cs
    {
        // [Required]
        // [Range(0, double.MaxValue)] -> toto použil u Price (já price nemám)

        [Required]
        [StringLength(100)]
        public string NazevProductu { get; set; }
        public string? PopisReceptu {  get; set; }
        public string Kategorie { get; set; }
        
        //public int CategoryId { get; set; }

        public string? Obtiznost { get; set; }
        public string? CasovaNarocnost { get; set; }
        public string? SeznamSurovin { get; set; }
        public string PostupPripravy { get; set; }
        public DateTime DatumVytvoreni { get; set; }  //datum vytvoření budu přidávat k receptu automaticky pomocí .js (asi), nebude to rozhodně zadávat uživatel
        //[Required] // -> zde ten required bude znamenat že MUSÍM povinně přidat obrázek k mému receptu (asi teda)
        public string? ImageSrc { get; set; }
        [NotMapped] // -> Toto myslím vysvětlovat tak že SQL není schopná přijmout adresu obrázku nebo tak něco. A tohle z toho prostě udělá nějakou
                    // bitovou řadu a pak to pujde
        [FileContent("image")]
        public IFormFile Image { get; set; } //přidám zde extra položku pro náš soubor, abych si nemusel mazat můj ImageSrc, který zrovna funguje
        // public string? ImageAlt { get; set; }  //chci dát ImageAlt do pryč, protože se mi to zdá totálně k ničemu
    }
}
