using Alone_Revisal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Context
{
    public class CucuContext : DbContext
    {
        public CucuContext(DbContextOptions<CucuContext> options) : base(options)
        {

        }
        public DbSet<Pontaj> Pontaje { get; set; }

    }
}