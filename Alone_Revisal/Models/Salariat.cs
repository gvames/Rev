using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alone_Revisal.Models
{

    [Table("Salariat")]
    public class Salariat
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [Key]
        public string CNP { get; set; }
    }
}