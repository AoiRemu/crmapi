using CRM.Common.Helpers;
using CRM.Models.View;

namespace CRM.Services.Interfaces
{
    public interface ICustomerMainService : IScopedService
    {
        public PageResponse<CustomerSearchViewModel> SearchList(CustomerSearchReuqest request);

        public ResultInfo Add(CustomerAddRequest request);

        public ResultInfo Update(CustomerAddRequest request);

        public ResultInfo BatchUpdateGroup(CustomerBatchGroupRequest request);

        public ResultInfo GiveUp(ulong customerId);

        public ResultInfo Allot(ulong customerId, AccountData accountData);

        public CustomerMainInfoViewModel GetDetail(ulong id);

        public ResultInfo UpdateStar(CustomerUpdateStarRequest request);

        public List<CommonOption<short>> GetFollowStateStep();

        public ResultInfo UpdateFollowState(ulong id, short followState);
    }
}
