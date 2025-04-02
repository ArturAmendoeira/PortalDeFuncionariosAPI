using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDeFuncionariosAPI.Models
{
    public class FilhoModel
    {

        public int Id { get; set; }
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public DateOnly DataDeNascimento { get; set; }
        public required FuncionarioModel Responsavel { get; set; }
    }
}
