using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class CustomerGroupRepository : Repository<CustomerGroupModel>, IScopedService
    {
        public CustomerGroupRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<CustomerGroupModel> SearchList()
        {
            return Context.Queryable<CustomerGroupModel>().ToList();
        }

        public CustomerGroupModel GetDetail(ulong id)
        {
            return Context.Queryable<CustomerGroupModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(CustomerGroupModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(CustomerGroupModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime }).ExecuteCommand() > 0;
        }
    }
}
