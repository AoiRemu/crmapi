using CRM.Common.Helpers;
using CRM.Models.View;

namespace CRM.Services.Interfaces
{
    public interface ICustomerGroupService : IScopedService
    {
        public PageResponse<CustomerGroupViewModel> SearchList(CustomerGroupRequest request);

        public ResultInfo Add(CustomerGroupViewModel model);

        public ResultInfo Update(CustomerGroupViewModel model);

        public ResultInfo Delete(ulong id);

        public List<CustomerGroupViewModel> GetOptions(CustomerGroupRequest request);
    }
}
