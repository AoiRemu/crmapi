using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;
using Models;

namespace CRM.Services
{
    public class CustomerTagService : ICustomerTagService
    {
        private CustomerTagRepository repository;
        public CustomerTagService(CustomerTagRepository repository)
        {
            this.repository = repository;
        }

        public List<CustomerTagViewModel> GetCustomerTagList(ulong id)
        {
            return repository.GetCustomerTagList(id);
        }

        public ResultInfo UpdateCustomerTags(CustomerTagUpdateRequest request)
        {
            var oldList = repository.GetListByCustomerId(request.CustomerId);
            var oldIdList = oldList.Select(a => a.TagId).ToList();
            var needDeleteIdList = oldIdList.Where(a => !request.TagIdList.Contains(a)).ToList();
            var needAddIdList = request.TagIdList.Where(a => !oldIdList.Contains(a)).ToList();

            try
            {
                if(needDeleteIdList.Any())
                {
                    repository.BatchDeleteByCustomerId(request.CustomerId, needDeleteIdList);
                }

                if (needAddIdList.Any())
                {
                    var list = needAddIdList.Select(a => new CustomerTagModel()
                    {
                        TagId = a,
                        CustomerId = request.CustomerId,
                    }).ToList();

                    repository.BatchAddInfo(list);
                }

                repository.CommitTran();
                return ResultInfo.Success("更新标签成功");
            }
            catch (Exception ex)
            {
                repository.RollTran();
                return ResultInfo.Fail("更新标签失败." + ex.Message);
            }

        }
    }
}
