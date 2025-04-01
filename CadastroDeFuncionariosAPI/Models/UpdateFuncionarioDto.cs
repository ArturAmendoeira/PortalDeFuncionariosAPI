using System.ComponentModel.DataAnnotations;

namespace CadastroDeFuncionariosAPI.Models
{
    public class UpdateFuncionarioDto
    {
        [Key]
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public int Departamento { get; set; }
        public double Salario { get; set; }
        public DateOnly DataDeNascimento { get; set; }
    }
}
