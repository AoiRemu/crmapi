using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class FollowUpLogRepository : Repository<FollowUpLogModel>, IScopedService
    {
        public FollowUpLogRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<FollowUpLogModel> SearchList()
        {
            return Context.Queryable<FollowUpLogModel>().ToList();
        }

        public FollowUpLogModel GetDetail(ulong id)
        {
            return Context.Queryable<FollowUpLogModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(FollowUpLogModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
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
