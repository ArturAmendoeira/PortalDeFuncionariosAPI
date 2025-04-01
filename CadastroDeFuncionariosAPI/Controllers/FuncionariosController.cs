using CadastroDeFuncionariosAPI.Data;
using CadastroDeFuncionariosAPI.Models;
using CadastroDeFuncionariosAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFuncionariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public FuncionariosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetTodosOsFuncionarios()
        {
            var todosOsFuncionarios = dbContext.Funcionarios.ToList();
            return Ok(todosOsFuncionarios);
        }
        [HttpGet]
        [Route("{nome}")]
        public IActionResult GetFuncionarioByNome(string nome)
        {
            var funcionario = dbContext.Funcionarios.FirstOrDefault(f => f.Nome== nome);
            if (funcionario is null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }
        [HttpGet]
        [Route("{departamento:int}")]
        public IActionResult GetFuncionarioByDepartamento(int departamento)
        {
            var funcionario = dbContext.Funcionarios.Where(f=> f.Departamento == departamento).ToList();
            if (!funcionario.Any())
            {
                return NotFound();
            }
            return Ok(funcionario);
        }
        [HttpPost]
        public IActionResult AddFuncionario(AddFuncionarioDto addFuncionarioDto)
        {
            var funcionarioEntidade = new Funcionario()
            {
                CPF = addFuncionarioDto.CPF,
                Nome = addFuncionarioDto.Nome,
                Departamento = addFuncionarioDto.Departamento,
                Salario = addFuncionarioDto.Salario,
                DataDeNascimento = addFuncionarioDto.DataDeNascimento
            };
            dbContext.Funcionarios.Add(funcionarioEntidade);
            dbContext.SaveChanges();

            return Ok(funcionarioEntidade); 
        }
        [HttpPut]
        [Route("{cpf}")]
        public IActionResult UpadateFuncionario(string cpf, UpdateFuncionarioDto updateFuncionarioDto)
        {
            var funcionario = dbContext.Funcionarios.Find(cpf);
            if(funcionario is null)
            {
                return NotFound();
            }
            
            funcionario.Nome = updateFuncionarioDto.Nome;
            funcionario.Departamento = updateFuncionarioDto.Departamento;
            funcionario.Salario = updateFuncionarioDto.Salario;
            funcionario.DataDeNascimento = updateFuncionarioDto.DataDeNascimento;

            dbContext.SaveChanges();
            return Ok(funcionario);

        }
        [HttpDelete]
        public IActionResult DeleteFuncionario(string cpf)
        {
            var funcionario = dbContext.Funcionarios.Find(cpf);
            if(funcionario is null)
            {
                return NotFound();
            }
            dbContext.Funcionarios.Remove(funcionario);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
