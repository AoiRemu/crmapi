using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class AccountMainController : BaseController
    {
        private IAccountMainService service;

        public AccountMainController(IAccountMainService service)
        {
            this.service = service;
        }
    }
}
