using Hex.Domain.Entities;

namespace Hex.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetAllPessoas();
        Task<Pessoa?> GetPessoaById(int id);
        Task SavePessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa);
        Task DeletePessoa(Pessoa pessoa);
    }
}
