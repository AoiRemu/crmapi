using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class CustomerGroupService : ICustomerGroupService
    {
        private CustomerGroupRepository repository;
        public CustomerGroupService(CustomerGroupRepository repository)
        {
            this.repository = repository;
        }
    }
}
