using Hex.Domain.Entities;

namespace Hex.Application.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAll();
        Task<Pessoa?> GetById(int id);
        Task Save(Pessoa pessoa);
        Task Update(Pessoa pessoa);
        Task Delete(Pessoa pessoa);
    }
}
