using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class ContractController : BaseController
    {
        private IContractService service;

        public ContractController(IContractService service)
        {
            this.service = service;
        }

        [HttpPost]
        public PageResponse<ContractViewModel> SearchList(ContractRequest request)
        {
            return service.SearchList(request);
        }

        [HttpPost]
        public ResultInfo Add(ContractViewModel model)
        {
            return service.Add(model, AccountData);
        }

        [HttpPut]
        public ResultInfo Update(ContractViewModel model)
        {
            return service.Update(model);
        }

        [HttpGet]
        public List<CommonOption<short>> GetContractOptions()
        {
            return service.GetContractOptions();
        }

        [HttpGet("{id}")]
        public ContractViewModel GetDetail(ulong id)
        {
            return service.GetDetail(id);
        }
    }
}
