using CRM.Common.Helpers;
using CRM.Models.View;

namespace CRM.Services.Interfaces
{
    public interface IContractService : IScopedService
    {
        public PageResponse<ContractViewModel> SearchList(ContractRequest request);

        public ResultInfo Add(ContractViewModel model, AccountData accountData);

        public ResultInfo Update(ContractViewModel model);

        public List<CommonOption<short>> GetContractOptions();

        public ContractViewModel GetDetail(ulong id);
    }
}
