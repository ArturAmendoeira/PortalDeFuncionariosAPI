using CadastroDeFuncionariosAPI.Dto.Funcionario;
using CadastroDeFuncionariosAPI.Models;

namespace CadastroDeFuncionariosAPI.Services.Funcionario
{
    public interface IFuncionarioInterface
    {
        Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionarios();
        Task<ResponseModel<FuncionarioModel>> BuscarFuncionario(string nome, int departamento);
        Task<ResponseModel<List<FuncionarioModel>>> CriarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto);
        Task<ResponseModel<List<FuncionarioModel>>> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto);
        Task<ResponseModel<List<FuncionarioModel>>> ExcluirFuncionario(int idFuncionario);

    }
}
