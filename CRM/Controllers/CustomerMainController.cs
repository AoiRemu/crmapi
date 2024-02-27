using CRM.Models.View;
using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class CustomerMainController : BaseController
    {
        private ICustomerMainService service;

        public CustomerMainController(ICustomerMainService service)
        {
            this.service = service;
        }

        public PageResponse<CustomerSearchViewModel> SearchList(CustomerSearchReuqest request)
        {
            return service.SearchList(request);
        }

        public ResultInfo Add(CustomerAddRequest request)
        {
            return service.Add(request);
        }

        public ResultInfo BatchUpdateGroup(CustomerBatchGroupRequest request)
        {
            return service.BatchUpdateGroup(request);
        }
    }
}
