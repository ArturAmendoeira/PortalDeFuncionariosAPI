using CadastroDeFuncionariosAPI.Dto.Vinculo;
using CadastroDeFuncionariosAPI.Models;

namespace CadastroDeFuncionariosAPI.Dto.Filho
{
    public class FilhoCriacaoDto
    {
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public DateOnly DataDeNascimento { get; set; }
        public required FuncionarioVinculoDto Responsavel { get; set; }
    }
}
