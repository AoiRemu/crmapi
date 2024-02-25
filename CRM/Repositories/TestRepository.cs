using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class TestRepository : Repository<AccountMainModel>, IScopedService
    {
        public TestRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<AccountMainModel> SearchList()
        {
            return Context.Queryable<AccountMainModel>().ToList();
        }

        public AccountMainModel GetDetail(ulong id)
        {
            return Context.Queryable<AccountMainModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(AccountMainModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(AccountMainModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime, a.Isdel }).ExecuteCommand() > 0;
        }
    }
}
