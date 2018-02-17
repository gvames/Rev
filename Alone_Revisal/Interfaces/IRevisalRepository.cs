using Alone_Revisal.Models;
using Alone_Revisal.RevisalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Interfaces
{
    public interface IRevisalRepository
    {
        IEnumerable<Angajat> GetAllSalariat();

        Salariat GetSalariatByCNP(string cnp);

    }
}
