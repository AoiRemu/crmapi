using CRM.Common.Helpers;
using CRM.Models.View;
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

        public List<CustomerTagViewModel> GetCustomerTagList(ulong customerId)
        {
            var query = Context.Queryable<CustomerTagModel>().LeftJoin<TagModel>((cust, tag) => cust.TagId == tag.Id).Where((cust, tag) => cust.CustomerId == customerId && tag.Isdel == 0);
            var result = query.Select((cust, tag) => new CustomerTagViewModel()
            {
                Ctime = cust.Ctime,
                CustomerId = cust.CustomerId,
                GroupId = tag.GroupId,
                Id = cust.Id,
                Name = tag.Name,
                Utime = cust.Utime,
            }).ToList();

            return result;
        }
    }
}
