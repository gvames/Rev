using Alone_Revisal.Context;
using Alone_Revisal.Interfaces;
using Alone_Revisal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Repository
{
    public class RepositoryRevisal : IRevisalRepository
    {
        //Private member
        private readonly RevisalContext _revisalContext;
        //Constructor
        //inject via dependency injection the context
        public RepositoryRevisal(RevisalContext revisalContext)
        {
            _revisalContext = revisalContext;
        }
        IEnumerable<Salariat> IRevisalRepository.GetAllAngajat()
        {
            return _revisalContext.Angajati;
        }

        Salariat IRevisalRepository.GetAngajatByCNP(string cnp)
        {
            return _revisalContext.Angajati.FirstOrDefault(p => p.CNP == cnp);
        }
    }
}
