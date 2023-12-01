using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo Login obrigatório.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Senha obrigatório.")]
        public string Password { get; set; }
    }
}
