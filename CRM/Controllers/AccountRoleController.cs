using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class AccountRoleController : BaseController
    {
        private IAccountRoleService service;

        public AccountRoleController(IAccountRoleService service)
        {
            this.service = service;
        }
    }
}
