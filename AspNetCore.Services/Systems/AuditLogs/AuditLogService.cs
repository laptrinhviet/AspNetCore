using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Interfaces;

namespace AspNetCore.Services.Systems.AuditLogs
{
    public class AuditLogService : WebServiceBase<Error, string, ErrorViewModel>, IAuditLogService 
    {
        private IRepository<Error, int> _errorRepository;
        private IUnitOfWork _unitOfWork;

        public AuditLogService(IRepository<Error, int> errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Error error)
        {
            _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}