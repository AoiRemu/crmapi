using CRM.Common.Helpers;
using CRM.Models.Enums;
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
            var query = Context.Queryable<CustomerMainModel>().LeftJoin<CustomerGroupModel>((main, group) => main.GroupId == group.Id);

            if (!string.IsNullOrEmpty(request.Name))
            {
                query.Where((main, group) => main.Name.Contains(request.Name));
            }

            if (request.State != null)
            {
                query.Where((main, group) => main.State == request.State);
            }

            if (request.GroupId != null)
            {
                query.Where((main, group) => main.GroupId == request.GroupId);
            }

            query.OrderByDescending((main, group) => main.Id);

            var result = query.Select((main, group) => new CustomerSearchViewModel()
            {
                Id = main.Id,
                Name = main.Name,
                FollowAccount = main.FollowAccount,
                FollowAccountId = main.FollowAccountId,
                Ctime = main.Ctime,
                FollowState = main.FollowState,
                GroupId = main.GroupId,
                GroupName = group.Name,
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
            return AsUpdateable(model).IgnoreColumns(a=> new {a.Ctime, a.Utime,a.State,a.FollowState}).Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public ulong AddInfo(CustomerMainModel model)
        {
            return (ulong)AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime, a.Isdel, a.FollowAccount, a.FollowAccountId }).ExecuteReturnIdentity();
        }

        public bool BatchGroup(CustomerBatchGroupRequest request)
        {
            return AsUpdateable().SetColumns(a => a.GroupId == request.GroupId).Where(a => request.CustomerIdList.Contains(a.Id)).ExecuteCommandHasChange();
        }

        public bool UpdateState(ulong customerId, short state)
        {
            return AsUpdateable().SetColumns(a => a.State == state).Where(a => a.Id == customerId).ExecuteCommandHasChange();
        }

        public List<CustomerMainModel> GetCustomerMainByGroupId(ulong groupId)
        {
            return AsQueryable().Where(a => a.GroupId == groupId).ToList();
        }

        public bool BatchUpdateGroupId(List<CustomerMainModel> list)
        {
            return AsUpdateable(list).UpdateColumns(a => new { a.GroupId }).ExecuteCommandHasChange();
        }

        public bool Allot(ulong customerId, ulong accountId, string account)
        {
            return AsUpdateable().SetColumns(a => a.FollowAccount == account).SetColumns(a=> a.FollowAccountId == accountId)
                .SetColumns(a=> a.State == (short)CustomerMainStateEnum.Allotted)
                .Where(a => a.Id == customerId).ExecuteCommandHasChange();
        }

        public bool UpdateStar(ulong id, short level)
        {
            return AsUpdateable().SetColumns(a => a.Level == level).Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool UpdateFollowState(ulong id, short followState)
        {
            return AsUpdateable().SetColumns(a => a.FollowState == followState).Where(a => a.Id == id).ExecuteCommandHasChange();
        }
    }
}
