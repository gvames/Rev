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
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }
        public List<SelectListItem> StantiereDisponibile { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }
        [Required]
        [Display(Name = "SantierID")]
        public int SantierID { get; set; }
        public string CNP { get; set; }

    }
}
