using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.RevisalModels
{
    public class ContractStare
    {
        public Guid Id { get; set; }
        public int Tip { get; set; }
        public int TipOperatie { get; set; }
        public DateTime DataIncetareSuspendare { get; set; }
        public DateTime DataIncetareDetasare { get; set; }
        [Key]
        public Guid ContractId { get; set; }

    }
}
