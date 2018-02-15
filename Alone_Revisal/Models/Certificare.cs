using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Models
{
    public class Certificare
    {
        [Key]
        public string CNP { get; set; }
        public string Descriere { get; set; }
    }
}
