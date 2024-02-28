using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;

namespace CRM.Services
{
    public class TagService : ITagService
    {
        private TagRepository repository;
        public TagService(TagRepository repository)
        {
            this.repository = repository;
        }

        public PageResponse<TagViewModel> SearchList(TagRequest request)
        {
            int total;
            var list = repository.SearchList(request, out total);
            var result = new PageResponse<TagViewModel>()
            {
                Data = list.Select(a => new TagViewModel(a)).ToList(),
                Total = total
            };

            return result;
        }

        public ResultInfo Add(TagViewModel model)
        {
            repository.AddInfo(model.ToDBModel());

            return ResultInfo.Success("添加标签成功");
        }

        public ResultInfo Update(TagViewModel model)
        {
            repository.UpdateInfo(model.ToDBModel());
            return ResultInfo.Success("更新标签成功");
        }

        public ResultInfo Delete(ulong id)
        {
            repository.FakeDelete(id);

            return ResultInfo.Success("删除标签成功");
        }
    }
}
