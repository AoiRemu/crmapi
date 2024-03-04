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
        public ResultInfo Update(CustomerAddRequest request)
        {
            return service.Update(request);
        }

        [HttpPut]
        public ResultInfo BatchUpdateGroup(CustomerBatchGroupRequest request)
        {
            return service.BatchUpdateGroup(request);
        }

        [HttpPut("{id}")]
        public ResultInfo GiveUp(ulong id)
        {
            return service.GiveUp(id);
        }

        [HttpPut("{id}")]
        public ResultInfo Allot(ulong id)
        {
            return service.Allot(id, AccountData);
        }

        [HttpGet("{id}")]
        public CustomerMainInfoViewModel GetDetail(ulong id)
        {
            return service.GetDetail(id);
        }

        [HttpPut]
        public ResultInfo UpdateStar(CustomerUpdateStarRequest request)
        {
            return service.UpdateStar(request);
        }

        [HttpGet]
        public List<CommonOption<short>> GetFollowStateStep()
        {
            return service.GetFollowStateStep();
        }

        [HttpPut("{id}/{followState}")]
        public ResultInfo UpdateFollowState(ulong id, short followState)
        {
            return service.UpdateFollowState(id, followState);
        }
    }
}
