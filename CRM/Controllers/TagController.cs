using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class TagController : BaseController
    {
        private ITagService service;

        public TagController(ITagService service)
        {
            this.service = service;
        }

        [HttpPost]
        public PageResponse<TagViewModel> SearchList(TagRequest request)
        {
            return service.SearchList(request);
        }

        [HttpPost]
        public ResultInfo Add(TagViewModel model)
        {
            return service.Add(model);
        }

        [HttpPut]
        public ResultInfo Update(TagViewModel model)
        {
            return service.Update(model);
        }

        [HttpPut]
        public ResultInfo Delete(ulong id)
        {
            return service.Delete(id);
        }
    }
}
