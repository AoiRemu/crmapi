using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;

namespace CRM.Services
{
    public class CustomerTagService : ICustomerTagService
    {
        private CustomerTagRepository repository;
        public CustomerTagService(CustomerTagRepository repository)
        {
            this.repository = repository;
        }

        public List<CustomerTagViewModel> GetCustomerTagList(ulong id)
        {
            return repository.GetCustomerTagList(id);
        }

        //public ResultInfo UpdateCustomerTag()
        //{

        //}
    }
}
