using Alone_Revisal.Models;
using Alone_Revisal.RevisalModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Context
{
    public class RevisalContext:DbContext
    {
        public RevisalContext(DbContextOptions<RevisalContext> options ) : base (options)
        {

        }
        public DbSet<Salariat> Salariati { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractStare> ContractStares { get; set; }
    }
}
