using CRM.Common.Helpers;
using CRM.Models.View;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class CustomerMainRepository : Repository<CustomerMainModel>, IScopedService
    {

        public CustomerMainRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<CustomerSearchViewModel> SearchList(CustomerSearchReuqest request, out int total)
        {
            total = 0;
            var query = AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
            {
                query.Where(a => a.Name.Contains(request.Name));
            }

            if (request.State != null)
            {
                query.Where(a => a.State == request.State);
            }

            if (request.GroupId != null)
            {
                query.Where(a => a.GroupId == request.GroupId);
            }

            Console.WriteLine(query.ToSqlString());

            var result = query.Select((main) => new CustomerSearchViewModel()
            {
                Id = main.Id,
                Name = main.Name,
                FollowAccount = main.FollowAccount,
                FollowAccountId = main.FollowAccountId,
                Ctime = main.Ctime,
                FollowState = main.FollowState,
                GroupId = main.GroupId,
                Level = main.Level,
                Phone = main.Phone,
                Qualification = main.Qualification,
                State = main.State,
            }).ToPageList(request.PageIndex, request.PageSize, ref total);

            return result;
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

        public ulong AddInfo(CustomerMainModel model)
        {
            return (ulong)AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime, a.Isdel }).ExecuteReturnIdentity();
        }

        public bool BatchGroup(CustomerBatchGroupRequest request)
        {
            return AsUpdateable().SetColumns(a => a.GroupId == request.GroupId).Where(a => request.CustomerIdList.Contains(a.Id)).ExecuteCommandHasChange();
        }
    }
}
