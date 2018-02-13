using Alone_Revisal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Interfaces
{
    public interface IRevisalRepository
    {
        IEnumerable<Salariat> GetAllAngajat();

        Salariat GetAngajatByCNP(string cnp);

    }
}
