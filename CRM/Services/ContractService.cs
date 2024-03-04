using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;
using CRM.Models.Enums;

namespace CRM.Services
{
    public class ContractService : IContractService
    {
        private ContractRepository repository;
        public ContractService(ContractRepository repository)
        {
            this.repository = repository;
        }

        public PageResponse<ContractViewModel> SearchList(ContractRequest request)
        {
            int total;
            var list = repository.SearchList(request, out total);
            var result = new PageResponse<ContractViewModel>()
            {
                Data = list.Select(a=> new ContractViewModel(a)).ToList(),
                Total = total
            };

            return result;
        }

        public ResultInfo Add(ContractViewModel model, AccountData accountData)
        {
            var dbModel = model.ToDBModel();
            dbModel.Account = accountData.Account;
            dbModel.AccountId = accountData.AccountId;
            repository.AddInfo(dbModel);

            return ResultInfo.Success("添加合同成功");
        }

        public ResultInfo Update(ContractViewModel model)
        {
            var result = repository.UpdateInfo(model.ToDBModel());
            return ResultInfo.Success("更新合同成功");
        }

        public List<CommonOption<short>> GetContractOptions()
        {
            var values = Enum.GetValues(typeof(ContractStateEnum));
            var result = new List<CommonOption<short>>();
            foreach (ContractStateEnum value in values)
            {
                result.Add(new CommonOption<short>()
                {
                    Label = value.ToString(),
                    Value = (short)value
                });
            }

            return result;
        }

        public ContractViewModel GetDetail(ulong id)
        {
            var model = repository.GetDetail(id);
            return new ContractViewModel(model);
        }
    }
}
