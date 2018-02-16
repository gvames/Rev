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
    public class RepositoryApp : IAppRepository
    {
        private readonly AppDbContext _cucuContext;


        public RepositoryApp(AppDbContext CucuContext)
        {
            _cucuContext = CucuContext;
        }

        IEnumerable<Pontaj> IAppRepository.GetPontajAll()
        {
            //returneaza toti angajatii
            return _cucuContext.Pontaje;
        }

        Pontaj IAppRepository.GetPontajByCNP(string cnp)
        {
            //returneaza o singura inregistrare dupa CNP
            return _cucuContext.Pontaje.FirstOrDefault(p => p.CNP == cnp);
        }
        

        Boolean IAppRepository.InsertPontaje(string cnp)
        {
     

            var salariat = _cucuContext.Salariati.FirstOrDefault(s => s.CNP == cnp);

            if (salariat != null)
            {
                Pontaj pontaj = new Pontaj
                {
                    CNP = salariat.CNP,
                    Nume = salariat.Nume,
                    Prenume = salariat.Prenume,
                    CNPResponsabil = salariat.CnpVechi,
                    DataPontaj = DateTime.Now,
                    Prezenta = true
                };
                var result = _cucuContext.Pontaje.Add(pontaj);
            }
           

          

            return true;
        }
    }
}
