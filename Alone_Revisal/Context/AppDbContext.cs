using Alone_Revisal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Context
{
    public class AppDbContext : IdentityDbContext<Utilizator>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Pontaj> Pontaje { get; set; }
        public DbSet<Angajat> Angajati { get; set; }
        public DbSet<Santier> Santiere { get; set; }
        public DbSet<Certificare> Certificari { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }
    }
}