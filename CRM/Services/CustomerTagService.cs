using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class CustomerTagService : ICustomerTagService
    {
        private CustomerTagRepository repository;
        public CustomerTagService(CustomerTagRepository repository)
        {
            this.repository = repository;
        }
    }
}
