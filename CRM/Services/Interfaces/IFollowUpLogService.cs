using CRM.Common.Helpers;
using CRM.Models.View;

namespace CRM.Services.Interfaces
{
    public interface IFollowUpLogService : IScopedService
    {
        public List<FollowUpLogViewModel> SearchList(FollowUpLogRequest request);

        public ResultInfo Add(FollowUpLogViewModel model, AccountData accountData);

        public ResultInfo Update(FollowUpLogViewModel model);

        public ResultInfo Delete(ulong id);
    }
}
