using CadastroDeFuncionariosAPI.Dto.Filho;
using CadastroDeFuncionariosAPI.Models;

namespace CadastroDeFuncionariosAPI.Services.Filho
{
    public interface IFilhoInterface
    {
        Task<ResponseModel<List<FilhoModel>>> ListarFilhosFuncionario(int idFuncionario);
        Task<ResponseModel<List<FilhoModel>>> CriarFilhoo(FilhoCriacaoDto filhoCriacaoDto);
        Task<ResponseModel<List<FilhoModel>>> EditarFilho(FilhoEdicaoDto filhoEdicaoDto);
        Task<ResponseModel<List<FilhoModel>>> ExcluirFilho(int idFilho);
    }
}
