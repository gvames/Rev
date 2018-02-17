using Alone_Revisal.Context;
using Alone_Revisal.Interfaces;
using Alone_Revisal.Models;
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
        IEnumerable<Angajat> IRevisalRepository.GetAllSalariat()
        {

            var listOfSalariat = (from con in _revisalContext.Contracts
                              join conStare in _revisalContext.ContractStare on con.StareCurentaId equals conStare.Id
                              join sal in _revisalContext.Salariati on con.SalariatId equals sal.Id
                              where conStare.Tip != 3
                              select new Angajat
                              {
                                  CNP = sal.CNP,
                                  CnpVechi = sal.CnpVechi,
                                  Adresa = sal.Adresa,
                                  Activ = sal.Activ,
                                  Apatrid = sal.Apatrid,
                                  TipActIdentitate = sal.TipActIdentitate,
                                  TipActualizare = sal.TipActualizare,
                                  Nume = sal.Nume,
                                  Prenume = sal.Prenume,
                                  Mentiuni = sal.Mentiuni,
                                  NumarItm = sal.NumarItm,
                                  Radiat = sal.Radiat,
                                  SerieItm = sal.SerieItm
                              });

            return listOfSalariat;
        }

        Salariat IRevisalRepository.GetSalariatByCNP(string cnp)
        {
            return _revisalContext.Salariati.FirstOrDefault(p => p.CNP == cnp);
        }
    }
}
