using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class AccountRoleRepository : Repository<AccountRoleModel>, IScopedService
    {
        public AccountRoleRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<AccountRoleModel> GetAccountRoles(ulong accountId)
        {
            return AsQueryable().Where(a => a.AccountId == accountId).ToList();
        }

        public List<AccountRoleModel> SearchList()
        {
            return Context.Queryable<AccountRoleModel>().ToList();
        }

        public AccountRoleModel GetDetail(ulong id)
        {
            return Context.Queryable<AccountRoleModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(AccountRoleModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(AccountRoleModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime }).ExecuteCommand() > 0;
        }
    }
}
