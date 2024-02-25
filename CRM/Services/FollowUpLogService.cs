using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class FollowUpLogService : IFollowUpLogService
    {
        private FollowUpLogRepository repository;
        public FollowUpLogService(FollowUpLogRepository repository)
        {
            this.repository = repository;
        }
    }
}
