using CRM.Common.Helpers;
using CRM.Models.View;

namespace CRM.Services.Interfaces
{
    public interface ICustomerTagService : IScopedService
    {
        public List<CustomerTagViewModel> GetCustomerTagList(ulong id);

        public ResultInfo UpdateCustomerTags(CustomerTagUpdateRequest request);
    }
}
