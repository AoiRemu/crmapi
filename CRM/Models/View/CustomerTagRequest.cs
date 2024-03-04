
namespace CRM.Models.View
{
    public class CustomerTagUpdateRequest
    {
        public ulong CustomerId { get; set; }

        public List<ulong> TagIdList { get; set; } = new List<ulong>();
    }

    public class CustomerTagViewModel
    {
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
        /// Desc:名称
        /// Default:0
        /// Nullable:False
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Desc:标签分组id
        /// Default:0
        /// Nullable:False
        /// </summary>
        public ulong GroupId { get; set; }

        /// <summary>
        /// 客户id
        /// </summary>
        public ulong CustomerId { get; set; }
    }
}
