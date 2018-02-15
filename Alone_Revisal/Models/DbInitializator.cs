using Alone_Revisal.Context;
using Alone_Revisal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alone_Revisal.RevisalModels;

namespace Alone_Revisal.Models
{
    public class DbInitializator
    {
        static IRevisalRepository _revisalRepository;

        public DbInitializator(IRevisalRepository revisalRepository)
        {
            _revisalRepository = revisalRepository;
        }

        public static void Initializate(AppDbContext appDbContext)
        {
            appDbContext.Database.EnsureCreated();

            if (appDbContext.Salariati.Any())
            {
                return;
            }

            //var salariati = _revisalRepository.GetAllAngajat();

            //foreach (Salariat salariat in salariati)
            //{
            //    Angajat angajat = new Angajat
            //    {
            //        CNP = salariat.CNP,
            //        Adresa = salariat.Adresa,
            //        CnpVechi = salariat.CnpVechi,
            //        Mentiuni = salariat.Mentiuni,
            //        Nume = salariat.Nume,
            //        Prenume = salariat.Prenume,
            //        NumarItm = salariat.NumarItm,
            //        Activ = salariat.Activ,
            //        Apatrid = salariat.Apatrid,
            //        Radiat = salariat.Radiat,
            //        TipActIdentitate = salariat.TipActIdentitate,
            //        TipActualizare = salariat.TipActualizare,
            //        SerieItm = salariat.SerieItm
            //    };
            //    appDbContext.Salariati.Add(angajat);
            //}
        }
    }
}
