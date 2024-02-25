using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class CustomerMainService : ICustomerMainService
    {
        private CustomerMainRepository repository;
        public CustomerMainService(CustomerMainRepository repository)
        {
            this.repository = repository;
        }
    }
}
