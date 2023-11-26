using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace djanak.Domain.Entities
{
    public class Product : Entity
    {
        public string NazevProductu { get; set; }
        public string Kategorie { get; set; }
        
        //public int CategoryId { get; set; }

        public string Obtiznost { get; set; }
        public string CasovaNarocnost { get; set; }
        public string PopisReceptu {  get; set; }
        public string SeznamSurovin { get; set; }
        public string PostupPripravy { get; set; }
        public DateTime DatumVytvoreni { get; set; }
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
    }
}
