using System.ComponentModel;

namespace CRM.Models.Enums
{
    public enum CustomerMainStateEnum
    {
        /// <summary>
        /// 新入库
        /// </summary>
        New = 0,

        /// <summary>
        /// 已认领
        /// </summary>
        Allotted = 1,

        /// <summary>
        /// 放弃
        /// </summary>
        Abandon = 2,

        /// <summary>
        /// 已成交
        /// </summary>
        DealDone = 3
    }

    public enum CustomerMainFollowStateEnum
    {
        /// <summary>
        /// 新入库
        /// </summary>
        [Description("新入库")]
        New = 0,

        /// <summary>
        /// 意向客户
        /// </summary>
        [Description("意向客户")]
        Intention = 1,

        /// <summary>
        /// 邀约上门
        /// </summary>
        [Description("邀约上门")]
        Invited = 2,

        /// <summary>
        /// 已签约
        /// </summary>
        [Description("已签约")]
        Signed = 3,

        /// <summary>
        /// 已放款
        /// </summary>
        [Description("已放款")]
        Disbursed = 4
    }
}
