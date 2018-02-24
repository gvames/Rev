using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Campul Username e gol.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lipsa parola.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Parola nu a fost confirmata.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }
        public List<SelectListItem> StantiereDisponibile { get; set; }
        [Required(ErrorMessage = "Alege un rol.")]
        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }
        [Required(ErrorMessage = "Alege un santier.")]
        [Display(Name = "SantierID")]
        public int SantierID { get; set; }
        public string CNP { get; set; }

    }
}
