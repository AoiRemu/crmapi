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
    }
}
