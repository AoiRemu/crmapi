using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private CustomerInfoRepository repository;
        public CustomerInfoService(CustomerInfoRepository repository)
        {
            this.repository = repository;
        }
    }
}
