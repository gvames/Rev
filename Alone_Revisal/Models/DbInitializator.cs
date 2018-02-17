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

        public static void Initializate(AppDbContext appDbContext)
        {
            appDbContext.Database.EnsureCreated();

        }
    }
}
