using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Domain
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Passsword", ErrorMessage = "Please confirm password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
