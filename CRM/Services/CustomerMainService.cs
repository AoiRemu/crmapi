using CRM.Services.Interfaces;
using CRM.Repositories;
using CRM.Models.View;

namespace CRM.Services
{
    public class CustomerMainService : ICustomerMainService
    {
        private CustomerMainRepository repository;
        private CustomerTagRepository tagRepository;
        private FollowUpLogRepository followUpLogRepository;
        private CustomerInfoRepository customerInfoRepository;

        public CustomerMainService(CustomerMainRepository repository)
        {
            this.repository = repository;
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

                return ResultInfo.Success("��ӿͻ��ɹ�");
            }
            catch (Exception)
            {
                repository.RollTran();
                return ResultInfo.Fail("��ӿͻ�ʧ��");
            }
        }

        public ResultInfo BatchUpdateGroup(CustomerBatchGroupRequest request)
        {
            if(request.CustomerIdList.Count == 0)
            {
                return ResultInfo.Fail("��ѡ����Ҫ��������Ŀͻ�");
            }

            repository.BatchGroup(request);

            return ResultInfo.Success("��������ɹ�");
        }
    }
}
