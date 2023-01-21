using Hex.Application.Repositories;
using Hex.Domain.Entities;
using Hex.Infra.Data;

namespace Hex.Infra.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(HexContext context) : base(context) { }
    }
}
