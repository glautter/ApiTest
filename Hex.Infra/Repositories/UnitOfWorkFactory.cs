using Hex.Application.Repositories;
using Hex.Infra.Data;

namespace Hex.Infra.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly HexContext hexContext;
        private IUnitOfWork _unitOfWork;

        public UnitOfWorkFactory(HexContext hexContext, IUnitOfWork unitOfWork)
        {
            this.hexContext = hexContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Scope(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("não encontrou função desenvolvida.");

            try
            {
                action();
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message);
            }
        }

        public IUnitOfWork StartNew()
        {
            return null;
        }
    }
}
