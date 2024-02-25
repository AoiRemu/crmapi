using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class ContractService : IContractService
    {
        private ContractRepository repository;
        public ContractService(ContractRepository repository)
        {
            this.repository = repository;
        }
    }
}
