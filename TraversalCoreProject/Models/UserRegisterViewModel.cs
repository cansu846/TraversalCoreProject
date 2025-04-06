using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Please enter your name...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname...")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your username...")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your mail...")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Please enter your password...")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter again your password...")]
        [Compare("Password",ErrorMessage ="Passwords not compatible")]
        public string ConfirmPassword { get; set; }    
    }
}
