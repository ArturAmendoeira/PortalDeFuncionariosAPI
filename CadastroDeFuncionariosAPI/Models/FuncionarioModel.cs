using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastroDeFuncionariosAPI.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public int Departamento { get; set; }
        public double Salario { get; set; }
        public DateOnly DataDeNascimento { get; set; }
        [JsonIgnore]
        public ICollection<FilhoModel>? Filhos { get; set; }

    }
}
