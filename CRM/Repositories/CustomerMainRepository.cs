using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class CustomerMainRepository : Repository<CustomerMainModel>, IScopedService
    {
        public CustomerMainRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<CustomerMainModel> SearchList()
        {
            return Context.Queryable<CustomerMainModel>().ToList();
        }

        public CustomerMainModel GetDetail(ulong id)
        {
            return Context.Queryable<CustomerMainModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(CustomerMainModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(CustomerMainModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime, a.Isdel }).ExecuteCommand() > 0;
        }
    }
}
