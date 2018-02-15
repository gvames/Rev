using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alone_Revisal.RevisalModels
{

    [Table("Salariat")]
    public class Salariat
    {
        [Key]
        public Guid Id { get; set; }       
        public string Nume { get; set; }
        public string Prenume { get; set; }        
        public string CNP { get; set; }
        public string CnpVechi  { get; set; }
        public int TipActualizare { get; set; }
        public int TipActIdentitate { get; set; }
        public string SerieItm { get; set; }
        public string NumarItm { get; set; }
        public string Adresa { get; set; }
        public string Mentiuni { get; set; }
        public int Activ { get; set; }
        public int Radiat { get; set; }
        public int? Apatrid { get; set; }
    }
}