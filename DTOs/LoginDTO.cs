using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiro.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = " Password is required")]
        public string? Password { get; set; }
    }
}
