using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class CustomerGroupController : BaseController
    {
        private ICustomerGroupService service;

        public CustomerGroupController(ICustomerGroupService service)
        {
            this.service = service;
        }
    }
}
