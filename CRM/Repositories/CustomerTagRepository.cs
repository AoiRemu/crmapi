using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class CustomerTagRepository : Repository<CustomerTagModel>, IScopedService
    {
        public CustomerTagRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<CustomerTagModel> SearchList()
        {
            return Context.Queryable<CustomerTagModel>().ToList();
        }

        public CustomerTagModel GetDetail(ulong id)
        {
            return Context.Queryable<CustomerTagModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(CustomerTagModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(CustomerTagModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime }).ExecuteCommand() > 0;
        }

        public List<CustomerTagModel> GetCustomerTagList(ulong customerId)
        {
            return AsQueryable().Where(a => a.CustomerId == customerId).ToList();
        }
    }
}
