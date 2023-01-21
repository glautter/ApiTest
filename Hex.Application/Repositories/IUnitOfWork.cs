namespace Hex.Application.Repositories
{
    public class UnitOfWorkAlreadyCompletedException : InvalidOperationException { }

    /// <summary>
    /// A business transaction or Unit of work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Finished or Complete Unit of work
        /// </summary>
        void Complete();
    }
}
