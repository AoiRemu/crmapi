using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class CustomerTagController : BaseController
    {
        private ICustomerTagService service;

        public CustomerTagController(ICustomerTagService service)
        {
            this.service = service;
        }
    }
}
