using App.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Campo Nome obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Login obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Email obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }
        public ProfileEnum Profile { get; set; }

        [Required(ErrorMessage = "Campo Senha obrigatório.")]
        public string Password {  get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
    }
}
