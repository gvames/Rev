﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alone_Revisal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alone_Revisal.Interfaces
{
    public interface ICucuRepository
    {
        IEnumerable<Pontaj> GetPontajAll();
        Pontaj GetPontajByCNP(string cnp);
        IActionResult UpdatePontaj(string cnp, DateTime dataPontaj, Boolean prezenta);
    }
}
