namespace Hex.Infra.Repositories
{
    public interface IRepository<DomainClass> where DomainClass : class
    {
        Task<IEnumerable<DomainClass>> GetAll();
        Task<DomainClass?> GetById(int id);
        Task Save(DomainClass objectDomain);
        Task Update(DomainClass objectDomain);
        Task Delete(DomainClass objectDomain);
    }
}
