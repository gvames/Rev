using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.RevisalModels
{
    [Table("Contract")]
    public class Contract
    {
        [Key]
        public Guid Id { get; set; }
        public int TipActualizare { get; set; }
        public DateTime DataConsemnare { get; set; }
        public int TipDurata { get; set; }
        public int TipNorma { get; set; }
        public int TipContract { get; set; }
        public string NumarContract { get; set; }
        public string NumarContractVechi { get; set; }
        public DateTime DataContract  { get; set; }
        public string DataContractVechi { get; set; }
        public DateTime DataInceputContract { get; set; }
        public DateTime DataSfarsitContract { get; set; }
        public int Salariu { get; set; }
        public int ExceptieDataSfarsit { get; set; }
        public string Detalii { get; set; }
        public int TimpMuncaNorma { get; set; }
        public int TimpMuncaRepartizare { get; set; }
        public int TimpMuncaIntervalTimp { get; set; }
        public int TimpMuncaDurata { get; set; }
        public int Radiat { get; set; }

        public ContractStare contractStare { get; }
    }
}



