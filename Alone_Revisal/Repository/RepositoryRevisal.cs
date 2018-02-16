using Alone_Revisal.Context;
using Alone_Revisal.Interfaces;
using Alone_Revisal.RevisalModels;
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
        IEnumerable<Salariat> IRevisalRepository.GetAllSalariat()
        {
            var result = from t in _revisalContext.Salariati
                         join sa in _revisalContext.Contracts on t.Id equals sa.SalariatId
                         select t;
            return _revisalContext.Salariati;
        }

        Salariat IRevisalRepository.GetSalariatByCNP(string cnp)
        {
            return _revisalContext.Salariati.FirstOrDefault(p => p.CNP == cnp);
        }
    }
}
