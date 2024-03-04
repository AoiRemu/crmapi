using CRM.Common.Helpers;
using CRM.Models.View;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class ContractRepository : Repository<ContractModel>, IScopedService
    {
        public ContractRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<ContractModel> SearchList(ContractRequest request, out int total)
        {
            total = 0;
            var query = AsQueryable();

            if(request.CustomerId != null)
            {
                query.Where(a => a.CustomerId == request.CustomerId);
            }

            if(request.AccountId != null)
            {
                query.Where(a => a.AccountId == request.AccountId);
            }

            if(request.Account != null && !string.IsNullOrEmpty(request.Account))
            {
                query.Where(a => request.Account.Contains(request.Account));
            }

            if(request.State != null)
            {
                query.Where(a => a.State == request.State);
            }

            if (!request.IsPage)
            {
                return query.ToList();
            }

            return query.ToPageList(request.PageIndex, request.PageSize, ref total);
        }

        public ContractModel GetDetail(ulong id)
        {
            return Context.Queryable<ContractModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(ContractModel model)
        {
            return AsUpdateable(model).UpdateColumns(a => new { a.SignTime, a.Amount, a.CustomerId, a.State }).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(ContractModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime }).ExecuteCommand() > 0;
        }
    }
}
