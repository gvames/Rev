using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Models
{
    public class Utilizator : IdentityUser
    {
        [Key]
        public string CNP { get; set; }
        public int IdSantier { get; set; }
    }
}
