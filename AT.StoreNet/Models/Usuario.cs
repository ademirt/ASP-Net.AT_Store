using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AT.StoreNet.Models
{
    [Table(nameof(Usuario))]
    public class Usuario : Entity
    {
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Campo '{0}' é obrigatório!"), StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo '{0}' é obrigatório!"), StringLength(80)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo '{0}' é obrigatório!"), StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Senha { get; set; }

    }
}
