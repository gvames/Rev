using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alone_Revisal.Models
{
    public class Pontaj
    {
        [Key]
        public string CNP { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNPResponsabil { get; set; }
        public DateTime DataPontaj { get; set; }
        public Boolean Prezenta { get; set; }
    }
}



