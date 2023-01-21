using Hex.Application.Interfaces;
using Hex.Application.Repositories;
using Hex.Domain.Entities;

namespace Hex.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;

        public IUnitOfWorkFactory UnitOfWorkFactory { get; }

        public PessoaService(IPessoaRepository pessoaRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.pessoaRepository = pessoaRepository;
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<IEnumerable<Pessoa>> GetAllPessoas()
        {
            return await this.pessoaRepository.GetAll();
        }

        public async Task<Pessoa?> GetPessoaById(int id)
        {
            return await this.pessoaRepository.GetById(id);
        }

        public async Task SavePessoa(Pessoa pessoa)
        {
            await UnitOfWorkFactory.Scope(() =>
            {
                this.pessoaRepository.Save(pessoa);
            });
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            await UnitOfWorkFactory.Scope(() =>
            {
                this.pessoaRepository.Update(pessoa);
            });
        }

        public async Task DeletePessoa(Pessoa pessoa)
        {
            await UnitOfWorkFactory.Scope(() =>
            {
                pessoaRepository.Delete(pessoa);
            });
        }
    }
}
