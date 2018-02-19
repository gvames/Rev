using Alone_Revisal.Context;
using Alone_Revisal.Interfaces;
using Alone_Revisal.Models;
using Alone_Revisal.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Repository
{
    public class RepositoryApp : IAppRepository
    {
        private readonly AppDbContext _appDbContext;


        public RepositoryApp(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<Angajat> GetAngajatiActiviAll()
        {
            return _appDbContext.Angajati;
        }

        public SQLExceptions InsertAngajat(IEnumerable<Angajat> angajati)
        {
            //insereaza lista de angajati in LocalDB
           _appDbContext.Angajati.AddRange(angajati);
            var result = _appDbContext.SaveChanges();

            if (result == 0)
                return SQLExceptions.UpdateFailed;

            return SQLExceptions.Ok;
        }

        IQueryable<Angajat> IAppRepository.GetAngajatiActiviAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Pontaj> IAppRepository.GetPontajAll()
        {
            //returneaza toti angajatii din tabela Pontaje
            return _appDbContext.Pontaje;
        }

        Pontaj IAppRepository.GetPontajByCNP(string cnp)
        {
            //returneaza o singura inregistrare dupa CNP
            return _appDbContext.Pontaje.FirstOrDefault(p => p.CNP == cnp);
        }

        SQLExceptions IAppRepository.InsertAngajat(IEnumerable<Angajat> angajat)
        {
            throw new NotImplementedException();
        }

        SQLExceptions IAppRepository.InsertPontaje(string cnp)
        {
            var salariat = _appDbContext.Angajati.FirstOrDefault(s => s.CNP == cnp);

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
                 _appDbContext.Pontaje.Add(pontaj);
                var result = _appDbContext.SaveChanges();
                if (result == 0)
                    return SQLExceptions.UpdateFailed;
            }
            return SQLExceptions.Ok;
        }

        SQLExceptions IAppRepository.InsertPontajeAll(IEnumerable<Pontaj> pontaje)
        {
            //insereaza lista de angajati pontati in LocalDB (tabela Pontaje)
            _appDbContext.Pontaje.AddRange(pontaje);          
          
            var result = _appDbContext.SaveChanges();

            if (result == 0)
                return SQLExceptions.UpdateFailed;

            return SQLExceptions.Ok;
        }
    }
}
