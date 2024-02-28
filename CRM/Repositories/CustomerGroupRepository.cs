using CRM.Common.Helpers;
using CRM.Models.View;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class CustomerGroupRepository : Repository<CustomerGroupModel>, IScopedService
    {
        public CustomerGroupRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<CustomerGroupModel> SearchList(CustomerGroupRequest request, out int total)
        {
            total = 0;
            var query = AsQueryable();
            if(request.Name != null && string.IsNullOrEmpty(request.Name))
            {
                query.Where(a => a.Name.Contains(request.Name));
            }

            if (request.IsPage)
            {
                return query.ToPageList(request.PageIndex, request.PageSize, ref total);
            }

            return query.ToList();

        }

        public CustomerGroupModel GetDetail(ulong id)
        {
            return Context.Queryable<CustomerGroupModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(CustomerGroupModel model)
        {
            return AsUpdateable(model).UpdateColumns(a => new { a.Name,a.ParentId }).ExecuteCommandHasChange();
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
