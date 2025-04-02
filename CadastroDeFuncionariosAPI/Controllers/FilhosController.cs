using CadastroDeFuncionariosAPI.Data;
using CadastroDeFuncionariosAPI.Dto.Filho;
using CadastroDeFuncionariosAPI.Dto.Funcionario;
using CadastroDeFuncionariosAPI.Models;
using CadastroDeFuncionariosAPI.Services.Filho;
using CadastroDeFuncionariosAPI.Services.Funcionario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFuncionariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilhoController : ControllerBase
    {
        private readonly IFilhoInterface _filhoInterface;
        public FilhoController(IFilhoInterface FilhoInterface)
        {
            _filhoInterface = FilhoInterface;
        }


        [HttpGet("ListarFilhosFuncionario/{id}")]
        public async Task<ActionResult<ResponseModel<List<FilhoModel>>>> ListarFilhosFuncionario(int id)
        {
            var filho = await _filhoInterface.ListarFilhosFuncionario(id);
            return Ok(filho);
        }


        [HttpPost("CriarFilho")]
        public async Task<ActionResult<ResponseModel<List<FilhoModel>>>> CriarFilho(FilhoCriacaoDto filhoCriacaoDto)
        {
            var filho = await _filhoInterface.CriarFilhoo(filhoCriacaoDto);
            return Ok(filho);
        }

        [HttpPut("EditarFilho")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> EditarFilho(FilhoEdicaoDto filhoEdicaoDto)
        {
            var filho = await _filhoInterface.EditarFilho(filhoEdicaoDto);
            return Ok(filho);
        }

        [HttpDelete("ExcluirFilho")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> ExcluirFilho(int idFilho)
        {
            var funcionario = await _filhoInterface.ExcluirFilho(idFilho);
            return Ok(funcionario);
        }
    }
}
