using System.ComponentModel.DataAnnotations;

namespace AT.StoreNet.ViewModels.Conta.Login
{
    public class LoginVM
    {
        [Required(ErrorMessage = "O {0} deve ser informado!")]
        [StringLength(40, ErrorMessage = "Limite do campo {0} é de {1}!")]
        [EmailAddress(ErrorMessage = "Endereço de {0} inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A {0} deve ser informado!")]
        [StringLength(30, ErrorMessage = "Limite do campo {0} é de {1}!")]
        public string Senha { get; set; }

        public bool PermanecerLogado { get; set; }

        public string ReturnUrl { get; set; }
    }
}
