using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class UpdatePasswordModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual do usuário.")]
        public string CurrentPassword {  get; set; }
        [Required(ErrorMessage = "Digite a nova senha do usuário.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha do usuário")]
        [Compare("NewPassword", ErrorMessage = "Senhas diferentes!")]
        public string ConfirmNewPassword { get; set; }
    }
}
