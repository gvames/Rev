using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Models
{
    public class Angajat
    {
        [Key]
        public string CNP { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CnpVechi { get; set; }
        public int TipActualizare { get; set; }
        public int TipActIdentitate { get; set; }
        public string SerieItm { get; set; }
        public string NumarItm { get; set; }
        public string Adresa { get; set; }
        public string Mentiuni { get; set; }
        public int Activ { get; set; }
        public int Radiat { get; set; }
        public int Apatrid { get; set; }

        public virtual Santier Santiere { get; set; }
        public virtual Certificare Certificari { get; set; }
    }
}
