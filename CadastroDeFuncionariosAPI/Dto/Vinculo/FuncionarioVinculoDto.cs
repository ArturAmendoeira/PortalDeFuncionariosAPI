namespace CadastroDeFuncionariosAPI.Dto.Vinculo
{
    public class FuncionarioVinculoDto
    {
        public int Id { get; set; }
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public int Departamento { get; set; }
        public double Salario { get; set; }
        public DateOnly DataDeNascimento { get; set; }
    }
}
