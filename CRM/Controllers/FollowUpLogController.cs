using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class FollowUpLogController : BaseController
    {
        private IFollowUpLogService service;

        public FollowUpLogController(IFollowUpLogService service)
        {
            this.service = service;
        }
    }
}
