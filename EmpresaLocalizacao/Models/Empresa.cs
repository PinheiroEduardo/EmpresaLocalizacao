using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmpresaLocalizacao.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Insira o campo Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o campo Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Insira o campo Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Insira o campo CEP")]
        [DisplayName("CEP")]
        [MaxLength(8, ErrorMessage = "Máximo {0} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Insira o campo Número")]
        [DisplayName("Número")]
        [MaxLength(6, ErrorMessage = "Máximo {0} caracteres")]
        public string Numero { get; set; }
    }
}