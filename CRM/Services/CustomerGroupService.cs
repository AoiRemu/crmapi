using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;

namespace CRM.Services
{
    public class CustomerGroupService : ICustomerGroupService
    {
        private CustomerGroupRepository repository;
        private CustomerMainRepository mainRepository;
        public CustomerGroupService(CustomerGroupRepository repository, CustomerMainRepository mainRepository)
        {
            this.repository = repository;
            this.mainRepository = mainRepository;
        }

        public PageResponse<CustomerGroupViewModel> SearchList(CustomerGroupRequest request)
        {
            int total;
            var list = repository.SearchList(request, out total);
            var result = new PageResponse<CustomerGroupViewModel>()
            {
                Data = list.Select(a => new CustomerGroupViewModel(a)).ToList(),
                Total = total
            };

            return result;
        }

        public ResultInfo Add(CustomerGroupViewModel model)
        {
            repository.AddInfo(model.ToDBModel());
            return ResultInfo.Success("添加客户分组成功");
        }

        public ResultInfo Update(CustomerGroupViewModel model)
        {
            repository.UpdateInfo(model.ToDBModel());
            return ResultInfo.Success("更新客户分组成功");
        }

        public ResultInfo Delete(ulong id)
        {
            try
            {
                repository.BeginTran();
                repository.DeleteInfo(id);
                var customerList = mainRepository.GetCustomerMainByGroupId(id);
                foreach (var customer in customerList)
                {
                    customer.GroupId = 0;
                }

                mainRepository.BatchUpdateGroupId(customerList);
                repository.CommitTran();

                return ResultInfo.Success("删除分组成功");
            }
            catch (Exception)
            {
                repository.RollTran();
                return ResultInfo.Fail("删除分组失败");
            }
        }

        public List<CustomerGroupViewModel> GetOptions(CustomerGroupRequest request)
        {
            int total;
            var list = repository.SearchList(request, out total);
            var result = list.Select(a => new CustomerGroupViewModel(a)).ToList();
            result.Insert(0, new CustomerGroupViewModel() { Name = "无" });
            return result;
        }
    }
}
