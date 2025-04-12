using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Areas.Member.Models
{
    public class UserEditViewModel
    {

        [Required(ErrorMessage = "Please enter your name...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname...")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your username...")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your mail...")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Please enter your phone number...")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your image url...")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter your password...")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter again your password...")]
        [Compare("Password", ErrorMessage = "Passwords not compatible")]
        public string ConfirmPassword { get; set; }
        public IFormFile Image { get; set; }
    }
}
