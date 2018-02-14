using Alone_Revisal.Context;
using Alone_Revisal.Interfaces;
using Alone_Revisal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Repository
{
    public class RepositoryCucu : ICucuRepository
    {
        private readonly CucuContext _cucuContext;

        public RepositoryCucu(CucuContext CucuContext)
        {
            _cucuContext = CucuContext;
        }

        IEnumerable<Pontaj> ICucuRepository.GetPontajAll()
        {
            //returneaza toti angajatii
            return _cucuContext.Pontaje;
        }

        Pontaj ICucuRepository.GetPontajByCNP(string cnp)
        {
            //returneaza o singura inregistrare dupa CNP
            return _cucuContext.Pontaje.FirstOrDefault(p => p.CNP == cnp);
        }

        IActionResult ICucuRepository.UpdatePontaj(string cnp, DateTime dataPontaj, bool prezenta)
        {

            return ;
        }
    }
}
