using Hex.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Hex.Infra.Repositories
{
    public class Repository<DomainClass> : IRepository<DomainClass> where DomainClass : class
    {
        protected readonly HexContext Context;

        protected DbSet<DomainClass> DbSet => Context.Set<DomainClass>();

        public Repository(HexContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<DomainClass>> GetAll() => await DbSet.ToListAsync();

        public async Task<DomainClass?> GetById(int id) => await DbSet.FindAsync(id);

        public async Task Save(DomainClass objectDomain)
        {
            await DbSet.AddAsync(objectDomain);
            Context.SaveChanges();
        }

        public async Task Update(DomainClass objectDomain)
        {
            Context.Entry(objectDomain).State = EntityState.Modified;
            Context.Update(objectDomain);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(DomainClass objectDomain)
        {
            Context.Entry(objectDomain).State = EntityState.Deleted;
            Context.Remove(objectDomain);
            await Context.SaveChangesAsync();
        }
    }
}
