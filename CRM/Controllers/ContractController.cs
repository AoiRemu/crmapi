using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class ContractController : BaseController
    {
        private IContractService service;

        public ContractController(IContractService service)
        {
            this.service = service;
        }
    }
}
