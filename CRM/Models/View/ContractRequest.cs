using Models;
using SqlSugar;
using System.Security.Principal;

namespace CRM.Models.View
{
    public class ContractRequest : PageRequest
    {
        public ulong? AccountId { get; set; }

        public string? Account { get; set; } = string.Empty;

        public short? State { get; set; }
    }

    public class ContractViewModel
    {
        public ContractViewModel() { }

        public ContractViewModel(ContractModel model)
        {
            Id = model.Id;
            AccountId = model.AccountId;
            Ctime = model.Ctime;
            Utime = model.Utime;
            Account = model.Account;
            Amount = model.Amount;
            SignTime = model.SignTime;
            State = model.State;
            CustomerId = model.CustomerId;
        }

        public ContractModel ToDBModel()
        {
            return new ContractModel
            {
                Amount = Amount,
                State = State,
                SignTime = SignTime,
            };
        }

        public ulong Id { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime Ctime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime Utime { get; set; }

        /// <summary>
        /// Desc:经理人
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Desc:经理人id
        /// Default:0
        /// Nullable:False
        /// </summary>
        public ulong AccountId { get; set; }

        /// <summary>
        /// Desc:金额
        /// Default:0
        /// Nullable:False
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Desc:签约时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime SignTime { get; set; }

        /// <summary>
        /// Desc:状态;0-拟定;1-谈判;2-已签约;3-签约失败;4-已放款;5-审批未通过;6-客户退单
        /// Default:0
        /// Nullable:False
        /// </summary>
        public short State { get; set; }

        /// <summary>
        /// Desc:客户id
        /// Default:0
        /// Nullable:False
        /// </summary>
        public ulong CustomerId { get; set; }
    }
}
