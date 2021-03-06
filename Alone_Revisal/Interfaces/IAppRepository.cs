﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alone_Revisal.Models;
using Alone_Revisal.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Alone_Revisal.Interfaces
{
    public interface IAppRepository
    {
        IEnumerable<Pontaj> GetPontajAll();
        SQLExceptions InsertPontajeAll(IEnumerable<Pontaj> pontaje);
        Pontaj GetPontajByCNP(string cnp);
        SQLExceptions InsertPontaje(string cnp);
        IQueryable<Angajat> GetAngajatiActiviAll();
        Angajat GetAngajatActivByCNP(string cnp);
        SQLExceptions InsertAngajat(IEnumerable<Angajat> angajat);
        IQueryable<Santier> GetSantierAll();
    }
}
