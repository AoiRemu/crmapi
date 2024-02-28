using CRM.Common.Helpers;
using CRM.Models.View;

namespace CRM.Services.Interfaces
{
    public interface ITagService : IScopedService
    {
        public PageResponse<TagViewModel> SearchList(TagRequest request);

        public ResultInfo Add(TagViewModel model);

        public ResultInfo Update(TagViewModel model);

        public ResultInfo Delete(ulong id);
    }
}
