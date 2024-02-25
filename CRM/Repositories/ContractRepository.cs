using CRM.Common.Helpers;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class ContractRepository : Repository<ContractModel>, IScopedService
    {
        public ContractRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<ContractModel> SearchList()
        {
            return Context.Queryable<ContractModel>().ToList();
        }

        public ContractModel GetDetail(ulong id)
        {
            return Context.Queryable<ContractModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(ContractModel model)
        {
            return AsUpdateable().Where(a => a.Id == model.Id).ExecuteCommandHasChange();
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
