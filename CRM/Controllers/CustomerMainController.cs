using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class CustomerMainController : BaseController
    {
        private ICustomerMainService service;

        public CustomerMainController(ICustomerMainService service)
        {
            this.service = service;
        }

        [HttpPost]
        public PageResponse<CustomerSearchViewModel> SearchList(CustomerSearchReuqest request)
        {
            return service.SearchList(request);
        }

        [HttpPost]
        public ResultInfo Add(CustomerAddRequest request)
        {
            return service.Add(request);
        }

        [HttpPut]
        public ResultInfo BatchUpdateGroup(CustomerBatchGroupRequest request)
        {
            return service.BatchUpdateGroup(request);
        }

        [HttpPut]
        public ResultInfo GiveUp(ulong customerId)
        {
            return service.GiveUp(customerId);
        }
    }
}
