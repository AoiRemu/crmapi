using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;

namespace CRM.Services
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private CustomerInfoRepository repository;
        public CustomerInfoService(CustomerInfoRepository repository)
        {
            this.repository = repository;
        }

        public CustomerInfoViewModel GetDetail(ulong customerId)
        {
            return new CustomerInfoViewModel(repository.GetDetail(customerId));
        }
    }
}
