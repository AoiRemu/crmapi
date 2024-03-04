using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class CustomerTagController : BaseController
    {
        private ICustomerTagService service;

        public CustomerTagController(ICustomerTagService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public List<CustomerTagViewModel> GetCustomerTagList(ulong id)
        {
            return service.GetCustomerTagList(id);
        }

        [HttpPost]
        public ResultInfo UpdateCustomerTags(CustomerTagUpdateRequest request)
        {
            return service.UpdateCustomerTags(request);
        }
    }
}
