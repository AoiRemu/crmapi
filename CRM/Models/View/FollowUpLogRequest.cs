using Models;

namespace CRM.Models.View
{
    public class FollowUpLogRequest
    {
        public ulong CustomerId { get; set; }
    }

    public class FollowUpLogViewModel
    {
        public FollowUpLogViewModel() { }

        public FollowUpLogViewModel(FollowUpLogModel model)
        {
            Id = model.Id;
            CustomerId = model.CustomerId;
            Ctime = model.Ctime;
            Utime = model.Utime;
            Message = model.Message;
            Account = model.Account;
            AccountId = model.AccountId;
            NextFollowTime = model.NextFollowTime;
        }

        public FollowUpLogModel ToDBModel()
        {
            return new FollowUpLogModel()
            {
                Id = Id,
                CustomerId = CustomerId,
                Message = Message,
                Account = Account,
                AccountId = AccountId ?? 0,
                NextFollowTime = NextFollowTime,
            };
        }

        public ulong Id { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime? Ctime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime? Utime { get; set; }

        /// <summary>
        /// Desc:信息
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Desc:跟进人
        /// Default:
        /// Nullable:False
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// Desc:跟进人id
        /// Default:0
        /// Nullable:False
        /// </summary>
        public ulong? AccountId { get; set; }

        /// <summary>
        /// Desc:下次跟进时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime NextFollowTime { get; set; }

        /// <summary>
        /// Desc:客户Id
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public ulong CustomerId { get; set; }
    }
}
