using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Models
{
    public class Santier
    {
        [Key]
        public int IdSantier { get; set; }
        public string Locatie { get; set; }
    }
}
