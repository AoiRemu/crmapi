using CRM.Common.Helpers;
using CRM.Models.View;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class FollowUpLogRepository : Repository<FollowUpLogModel>, IScopedService
    {
        public FollowUpLogRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<FollowUpLogModel> SearchList(FollowUpLogRequest request)
        {
            return AsQueryable().Where(a => a.CustomerId == request.CustomerId).ToList();
        }

        public FollowUpLogModel GetDetail(ulong id)
        {
            return Context.Queryable<FollowUpLogModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(FollowUpLogModel model)
        {
            return AsUpdateable(model).IgnoreColumns(a => new { a.Ctime, a.Utime }).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(FollowUpLogModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime }).ExecuteCommand() > 0;
        }

        public FollowUpLogModel? GetLastLog(ulong customerId)
        {
            return AsQueryable().Where(a => a.CustomerId == customerId).OrderByDescending(a => a.Ctime).First();
        }
    }
}
