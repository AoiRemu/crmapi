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
}
