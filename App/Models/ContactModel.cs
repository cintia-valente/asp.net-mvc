using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Email obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Telefone obrigatório.")]
        [Phone(ErrorMessage = "Número de telefone inválido!.")]
        public string PhoneNumber { get; set; }
    }
}
