using CadastroDeFuncionariosAPI.Data;
using CadastroDeFuncionariosAPI.Dto.Filho;
using CadastroDeFuncionariosAPI.Dto.Funcionario;
using CadastroDeFuncionariosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeFuncionariosAPI.Services.Filho
{
    public class FilhoService : IFilhoInterface
    {
        private readonly ApplicationDbContext _context;
        public FilhoService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<List<FilhoModel>>> CriarFilhoo(FilhoCriacaoDto filhoCriacaoDto)
        {
            ResponseModel<List<FilhoModel>> resposta = new ResponseModel<List<FilhoModel>>();
            try
            {
                var funcionario = await _context.Funcionarios
                    .FirstOrDefaultAsync(funcionarioBanco => funcionarioBanco.Id == filhoCriacaoDto.Responsavel.Id);

                if (funcionario == null)
                {
                    resposta.Mensagem = "nenhum registro";
                    return resposta;
                }

                var filho = new FilhoModel()
                {
                    Nome = filhoCriacaoDto.Nome,
                    CPF = filhoCriacaoDto.CPF,
                    DataDeNascimento = filhoCriacaoDto.DataDeNascimento,
                    Responsavel = funcionario
                };

                _context.Add(filho);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Filhos.Include(r => r.Responsavel).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilhoModel>>> EditarFilho(FilhoEdicaoDto filhoEdicaoDto)
        {
            ResponseModel<List<FilhoModel>> resposta = new ResponseModel<List<FilhoModel>>();
            try
            {
                var filho = await _context.Filhos
                    .Include(r => r.Responsavel)
                    .FirstOrDefaultAsync(filhoBanco => filhoBanco.Id == filhoEdicaoDto.Id);

                if (filho == null)
                {
                    resposta.Mensagem = "nenhum registro";
                    return resposta;
                }

                filho.DataDeNascimento = filhoEdicaoDto.DataDeNascimento;
                filho.CPF = filhoEdicaoDto.CPF;
                filho.Nome = filhoEdicaoDto.Nome;
                filho.Responsavel = filhoEdicaoDto.Responsavel;

                _context.Update(filho);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Filhos.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilhoModel>>> ExcluirFilho(int idFilho)
        {
            ResponseModel<List<FilhoModel>> resposta = new ResponseModel<List<FilhoModel>>();
            try
            {
                var filho = await _context.Filhos
                    .FirstOrDefaultAsync(filhoBanco => filhoBanco.Id == idFilho);

                if (filho == null)
                {
                    resposta.Mensagem = "nenhum registro";
                    return resposta;
                }

                _context.Remove(filho);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Filhos.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilhoModel>>> ListarFilhosFuncionario(int idFuncionario)
        {
            ResponseModel<List<FilhoModel>> resposta = new ResponseModel<List<FilhoModel>>();
            try
            {
                var Filho = await _context.Filhos
                    .Include(r => r.Responsavel)
                    .Where(FilhoBanco => FilhoBanco.Responsavel.Id == idFuncionario)
                    .ToListAsync();

                if (Filho == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = Filho;
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
