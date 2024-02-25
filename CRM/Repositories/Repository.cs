namespace CRM.Repositories
{
    using SqlSugar;
    using SqlSugar.Extensions;
    public class Repository<T> : SimpleClient<T> where T : class, new()
    {
        public Repository(ISqlSugarClient db)
        {
            base.Context = db;
        }

        public void BeginTran()
        {
            base.Context.AsTenant().BeginTran();
        }

        public void CommitTran()
        {
            base.Context.AsTenant().CommitTran();
        }

        public void RollTran()
        {
            base.Context.AsTenant().RollbackTran();
        }
    }
}
