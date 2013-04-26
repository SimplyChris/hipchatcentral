using System.ComponentModel.DataAnnotations;

namespace HipChatCentral.Domain.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordReEntry { get; set; }
    }
}