using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace djanak.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
