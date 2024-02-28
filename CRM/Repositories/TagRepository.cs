using CRM.Common.Helpers;
using CRM.Models.Enums;
using CRM.Models.View;
using Models;
using SqlSugar;

namespace CRM.Repositories
{
    public class TagRepository : Repository<TagModel>, IScopedService
    {
        public TagRepository(ISqlSugarClient db) : base(db)
        {
        }

        public List<TagModel> SearchList(TagRequest request, out int total)
        {
            total = 0;
            var query = AsQueryable().Where(a => a.Isdel == 0);
            if(request.GroupId != null)
            {
                query.Where(a => a.GroupId == request.GroupId);
            }

            if(request.Name != null && !string.IsNullOrEmpty(request.Name))
            {
                query.Where(a => a.Name.Contains(request.Name));
            }

            if (request.IsPage)
            {
                return query.ToPageList(request.PageIndex, request.PageSize, ref total);
            }

            return query.ToList();
        }

        public TagModel GetDetail(ulong id)
        {
            return Context.Queryable<TagModel>().Where(a => a.Id == id).First();
        }

        public bool UpdateInfo(TagModel model)
        {
            return AsUpdateable(model).IgnoreColumns(a=> new {a.Utime,a.Ctime,a.Id}).Where(a => a.Id == model.Id).ExecuteCommandHasChange();
        }

        public bool DeleteInfo(ulong id)
        {
            return AsDeleteable().Where(a => a.Id == id).ExecuteCommandHasChange();
        }

        public bool AddInfo(TagModel model)
        {
            return AsInsertable(model).IgnoreColumns(a => new { a.Ctime, a.Utime, a.Isdel,a.Id }).ExecuteCommand() > 0;
        }

        public bool FakeDelete(ulong id)
        {
            return AsUpdateable().SetColumns(a => a.Isdel == (short)IsdelEnum.Yes).ExecuteCommandHasChange();
        }
    }
}
