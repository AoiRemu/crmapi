using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;
using CRM.Models.Enums;
using CRM.Common.Helpers;
using CRM.Commons.Helpers;
using Models;

namespace CRM.Services
{
    public class CustomerMainService : ICustomerMainService
    {
        private CustomerMainRepository repository;
        private CustomerTagRepository tagRepository;
        private FollowUpLogRepository followUpLogRepository;
        private CustomerInfoRepository customerInfoRepository;

        public CustomerMainService(CustomerMainRepository repository, CustomerTagRepository tagRepository, 
            FollowUpLogRepository followUpLogRepository, CustomerInfoRepository customerInfoRepository)
        {
            this.repository = repository;
            this.tagRepository = tagRepository;
            this.followUpLogRepository = followUpLogRepository;
            this.customerInfoRepository = customerInfoRepository;
        }

        public PageResponse<CustomerSearchViewModel> SearchList(CustomerSearchReuqest request)
        {
            int total;
            var list = repository.SearchList(request, out total);

            foreach (var item in list)
            {
                item.NextFollowTime = followUpLogRepository.GetLastLog(item.Id)?.NextFollowTime;
                item.Tags = tagRepository.GetCustomerTagList(item.Id);
            }

            var result = new PageResponse<CustomerSearchViewModel>()
            {
                Total = total,
                Data = list
            };

            return result;
        }

        public ResultInfo Add(CustomerAddRequest request)
        {
            try
            {
                repository.BeginTran();
                var customerId = repository.AddInfo(request.Main.ToDBModel());
                var infoModel = request.Info.ToDBModel();
                infoModel.CustomerId = customerId;
                customerInfoRepository.AddInfo(infoModel);
                repository.CommitTran();

                return ResultInfo.Success("添加客户成功");
            }
            catch (Exception ex)
            {
                repository.RollTran();
                return ResultInfo.Fail("添加客户失败." + ex.Message);
            }
        }

        public ResultInfo Update(CustomerAddRequest request)
        {
            try
            {
                repository.BeginTran();
                repository.UpdateInfo(request.Main.ToDBModel());
                customerInfoRepository.UpdateInfo(request.Info.ToDBModel());
                repository.CommitTran();

                return ResultInfo.Success("更新客户信息成功");
            }
            catch (Exception ex)
            {
                repository.RollTran();
                return ResultInfo.Fail("更新客户信息失败." + ex.Message);
            }
        }

        public ResultInfo BatchUpdateGroup(CustomerBatchGroupRequest request)
        {
            if(request.CustomerIdList.Count == 0)
            {
                return ResultInfo.Fail("请选择需要批量分组的客户");
            }

            repository.BatchGroup(request);

            return ResultInfo.Success("批量分组成功");
        }

        public ResultInfo GiveUp(ulong customerId)
        {
            repository.UpdateState(customerId, (short)CustomerMainStateEnum.Abandon);
            return ResultInfo.Success("放弃成功");
        }

        public ResultInfo Allot(ulong customerId, AccountData accountData)
        {
            repository.Allot(customerId, accountData.AccountId, accountData.Account);
            return ResultInfo.Success("认领成功");
        }

        public CustomerMainInfoViewModel GetDetail(ulong id)
        {
            return new CustomerMainInfoViewModel(repository.GetDetail(id));
        }

        public ResultInfo UpdateStar(CustomerUpdateStarRequest request)
        {
            repository.UpdateStar(request.Id, request.Level);

            return ResultInfo.Success("更新客户星级成功");
        }

        public List<CommonOption<short>> GetFollowStateStep()
        {
            var values = Enum.GetValues(typeof(CustomerMainFollowStateEnum));
            var result = new List<CommonOption<short>>();
            foreach (CustomerMainFollowStateEnum item in values)
            {
                result.Add(new CommonOption<short>()
                {
                    Label = item.GetDescription(),
                    Value = (short)item
                });
            }

            return result;
        }

        public ResultInfo UpdateFollowState(ulong id, short followState)
        {
            repository.UpdateFollowState(id, followState);

            return ResultInfo.Success("更新跟进状态成功");
        }

        public ResultInfo ImportCustomers(IFormFileCollection files, AccountData accountData)
        {
            var result = ExcelHelper.ReadExcel<CustomerImportItemModel>(files);
            if (!result.IsSuccess)
            {
                return ResultInfo.Fail(result.Message);
            }

            try
            {
                repository.BeginTran();

                foreach (var item in result.ResultData)
                {
                    var mainModel = item.ToDBModel();
                    var id = repository.AddInfo(mainModel);
                    var infoModel = new FollowUpLogModel()
                    {
                        Account = accountData.Account,
                        AccountId = accountData.AccountId,
                        CustomerId = id,
                        Message = item.FollowContent,
                    };

                    followUpLogRepository.AddInfo(infoModel);
                }

                repository.CommitTran();

                return ResultInfo.Success("导入数据成功");
            }
            catch (Exception ex)
            {
                repository.RollTran();
                return ResultInfo.Fail("导入数据失败."+ ex.Message);
            }
        }
    }
}
