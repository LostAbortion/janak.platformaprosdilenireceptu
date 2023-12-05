using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace djanak.Domain.Entities
{
    public class Carousel : Entity
    {
        [Required]
        public string? ImageSrc { get; set; }
        public string? ImageAlt { get; set; }
    }
}
