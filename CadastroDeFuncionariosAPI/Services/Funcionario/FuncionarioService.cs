using CadastroDeFuncionariosAPI.Data;
using CadastroDeFuncionariosAPI.Dto.Funcionario;
using CadastroDeFuncionariosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeFuncionariosAPI.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<ResponseModel<FuncionarioModel>> BuscarFuncionario(string nome, int departamento)
        {
            ResponseModel<FuncionarioModel> resposta = new ResponseModel<FuncionarioModel>();
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionarioBanco =>
                (funcionarioBanco.Nome == nome) && (funcionarioBanco.Departamento == departamento));
                if (funcionario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }
                resposta.Dados = funcionario;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> CriarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                var funcionario = new FuncionarioModel()
                {
                    CPF = funcionarioCriacaoDto.CPF,
                    Nome = funcionarioCriacaoDto.Nome,
                    DataDeNascimento = funcionarioCriacaoDto.DataDeNascimento,
                    Departamento = funcionarioCriacaoDto.Departamento,
                    Salario = funcionarioCriacaoDto.Salario
                };
                _context.Add(funcionario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Funcionário criado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                var funcionario = await _context.Funcionarios
                    .FirstOrDefaultAsync(funcionarioBanco => funcionarioBanco.Id == funcionarioEdicaoDto.Id);

                if (funcionario == null)
                {
                    resposta.Mensagem = "nenhum funcionario localizado";
                    return resposta;
                }

                funcionario.Nome = funcionarioEdicaoDto.Nome;
                funcionario.Salario = funcionarioEdicaoDto.Salario;
                funcionario.Departamento = funcionarioEdicaoDto.Departamento;
                funcionario.DataDeNascimento = funcionarioEdicaoDto.DataDeNascimento;
                funcionario.CPF = funcionarioEdicaoDto.CPF;

                _context.Update(funcionario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Funcionario Alterado";
                return resposta;

            }
            catch (Exception ex )
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> ExcluirFuncionario(int idFuncionario)
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();

            try
            {
                var funcionario = await _context.Funcionarios
                    .FirstOrDefaultAsync(funcionarioBanco => funcionarioBanco.Id == idFuncionario);

                if (funcionario == null)
                {
                    resposta.Mensagem = "nenhum funcionario localizado";
                    return resposta;
                }

                _context.Remove(funcionario);

                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Autor Removido";

                return resposta;
                
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionarios()
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                var todosOsFuncionarios = await _context.Funcionarios.ToListAsync();
                resposta.Dados = todosOsFuncionarios;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

    }
}
