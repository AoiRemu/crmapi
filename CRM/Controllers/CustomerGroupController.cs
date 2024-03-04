using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class CustomerGroupController : BaseController
    {
        private ICustomerGroupService service;

        public CustomerGroupController(ICustomerGroupService service)
        {
            this.service = service;
        }

        [HttpPost]
        public PageResponse<CustomerGroupViewModel> SearchList(CustomerGroupRequest request)
        {
            return service.SearchList(request);
        }

        [HttpPost]
        public ResultInfo Add(CustomerGroupViewModel model)
        {
            return service.Add(model);
        }

        [HttpPut]
        public ResultInfo Update(CustomerGroupViewModel model)
        {
            return service.Update(model);
        }

        [HttpDelete("{id}")]
        public ResultInfo Delete(ulong id)
        {
            return service.Delete(id);
        }

        [HttpPost]
        public List<CustomerGroupViewModel> GetOptions(CustomerGroupRequest request)
        {
            return service.GetOptions(request);
        }
    }
}
