using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///跟进日志
    ///</summary>
    [SugarTable("follow_up_log")]
    public partial class FollowUpLogModel
    {
        public FollowUpLogModel()
        {


        }
        /// <summary>
        /// Desc:主键Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public ulong Id { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "ctime")]
        public DateTime Ctime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "utime")]
        public DateTime Utime { get; set; }

        /// <summary>
        /// Desc:信息
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Desc:跟进人
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "account")]
        public string Account { get; set; }

        /// <summary>
        /// Desc:跟进人id
        /// Default:0
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "account_id")]
        public ulong AccountId { get; set; }

        /// <summary>
        /// Desc:下次跟进时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "next_follow_time")]
        public DateTime NextFollowTime { get; set; }

        /// <summary>
        /// Desc:下次跟进时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "customer_id")]
        public ulong CustomerId { get; set; }
    }
}
