using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class RedefinePasswordModel
    {
        [Required(ErrorMessage = "Campo Login obrigatório.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Email obrigatório.")]
        public string Email { get; set; }
    }
}
