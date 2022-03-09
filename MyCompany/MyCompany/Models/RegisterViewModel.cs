using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required] [Display(Name = "Логин")] public string UserName { get; set; }

        [Required]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Желаемая роль")]
        public string DesiredRole { get; set; }
    }
}