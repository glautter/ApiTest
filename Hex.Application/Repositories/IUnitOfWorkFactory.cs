namespace Hex.Application.Repositories
{
    public interface IUnitOfWorkFactory
    {
        Task Scope(Action action);
    }
}
