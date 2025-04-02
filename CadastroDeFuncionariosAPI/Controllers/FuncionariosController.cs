using CadastroDeFuncionariosAPI.Data;
using CadastroDeFuncionariosAPI.Dto.Funcionario;
using CadastroDeFuncionariosAPI.Models;
using CadastroDeFuncionariosAPI.Services.Funcionario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFuncionariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionariosController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }


        [HttpGet("ListarFuncionarios")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> ListarFuncionarios()
        {
            var funcionarios = await _funcionarioInterface.ListarFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("BuscarFuncionarios/{nome}&{departamento}")]

        public async Task<ActionResult<ResponseModel<FuncionarioModel>>> BuscarFuncionarios(string nome, int departamento)
        {
            var funcionario = await _funcionarioInterface.BuscarFuncionario(nome, departamento);
            return Ok(funcionario);
        }

        [HttpPost("CriarFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> CriarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            var funcionario = await _funcionarioInterface.CriarFuncionario(funcionarioCriacaoDto);
            return Ok(funcionario);
        }

        [HttpPut("EditarFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            var funcionario = await _funcionarioInterface.EditarFuncionario(funcionarioEdicaoDto);
            return Ok(funcionario);
        }

        [HttpDelete("ExcluirFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> ExcluirFuncionario(int idFuncionario)
        {
            var funcionario = await _funcionarioInterface.ExcluirFuncionario(idFuncionario);
            return Ok(funcionario);
        }
    }
}
