using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;

namespace CRM.Services
{
    public class FollowUpLogService : IFollowUpLogService
    {
        private FollowUpLogRepository repository;
        public FollowUpLogService(FollowUpLogRepository repository)
        {
            this.repository = repository;
        }

        public List<FollowUpLogViewModel> SearchList(FollowUpLogRequest request)
        {
            var list = repository.SearchList(request);
            var result = list.Select(a => new FollowUpLogViewModel(a)).ToList();
            return result;
        }


        public ResultInfo Add(FollowUpLogViewModel model, AccountData accountData)
        {
            var dbModel = model.ToDBModel();
            dbModel.Account = accountData.Account;
            dbModel.AccountId = accountData.AccountId;
            repository.AddInfo(dbModel);

            return ResultInfo.Success("添加跟进记录成功");
        }

        public ResultInfo Update(FollowUpLogViewModel model)
        {
            repository.UpdateInfo(model.ToDBModel());

            return ResultInfo.Success("更新跟进记录成功");
        }

        public ResultInfo Delete(ulong id)
        {
            repository.DeleteInfo(id);
            return ResultInfo.Success("删除跟进记录成功");
        }
    }
}
