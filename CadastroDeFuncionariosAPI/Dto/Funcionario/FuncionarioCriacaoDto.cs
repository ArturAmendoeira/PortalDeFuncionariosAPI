namespace CadastroDeFuncionariosAPI.Dto.Funcionario
{
    public class FuncionarioCriacaoDto
    {
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public int Departamento { get; set; }
        public double Salario { get; set; }
        public DateOnly DataDeNascimento { get; set; }
    }
}
