using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class CustomerInfoRepository : Repository<CustomerInfoModel>, IScopedService
    {
        public CustomerInfoRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<CustomerInfoModel> SearchList()
        {
            return Context.Queryable<CustomerInfoModel>().ToList();
        }

        public CustomerInfoModel GetDetail(ulong id)
        {
            return Context.Queryable<CustomerInfoModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(CustomerInfoModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(CustomerInfoModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime, }).ExecuteCommand() > 0;
        }
    }
}
