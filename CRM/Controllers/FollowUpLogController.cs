using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class FollowUpLogController : BaseController
    {
        private IFollowUpLogService service;

        public FollowUpLogController(IFollowUpLogService service)
        {
            this.service = service;
        }

        [HttpPost]
        public List<FollowUpLogViewModel> SearchList(FollowUpLogRequest request)
        {
            return service.SearchList(request);
        }

        [HttpPost]
        public ResultInfo Add(FollowUpLogViewModel model)
        {
            return service.Add(model, AccountData);
        }
    }
}
