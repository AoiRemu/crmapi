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

            return query.ToPageList(request.PageIndex, request.PageSize, ref total);
        }

        public ContractModel GetDetail(ulong id)
        {
            return Context.Queryable<ContractModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(ContractModel model)
        {
            return AsUpdateable(model).IgnoreColumns(a=> new {a.Id, a.AccountId,a.Account,a.Ctime,a.Utime}).Where(a => a.Id == model.Id).ExecuteCommandHasChange();
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
