using CRM.Common.Helpers;
using CRM.Models.View;

namespace CRM.Services.Interfaces
{
    public interface ICustomerInfoService : IScopedService
    {
        public CustomerInfoViewModel GetDetail(ulong customerId);
    }
}
