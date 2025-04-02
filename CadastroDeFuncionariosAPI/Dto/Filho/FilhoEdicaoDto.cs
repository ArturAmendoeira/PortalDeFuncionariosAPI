using CadastroDeFuncionariosAPI.Models;

namespace CadastroDeFuncionariosAPI.Dto.Filho
{
    public class FilhoEdicaoDto
    {
        public int Id { get; set; }
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public DateOnly DataDeNascimento { get; set; }
        public required FuncionarioModel Responsavel { get; set; }
    }
}
