using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class CustomerInfoController : BaseController
    {
        private ICustomerInfoService service;

        public CustomerInfoController(ICustomerInfoService service)
        {
            this.service = service;
        }
    }
}
