using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///合同
    ///</summary>
    [SugarTable("contract")]
    public partial class ContractModel
    {
           public ContractModel(){


           }
           /// <summary>
           /// Desc:主键Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public ulong Id {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="ctime")]           
           public DateTime Ctime {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="utime")]           
           public DateTime Utime {get;set;}

           /// <summary>
           /// Desc:经理人
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="account")]           
           public string Account {get;set;}

           /// <summary>
           /// Desc:经理人id
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="account_id")]           
           public ulong AccountId {get;set;}

           /// <summary>
           /// Desc:金额
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="amount")]           
           public decimal Amount {get;set;}

           /// <summary>
           /// Desc:签约时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="sign_time")]           
           public DateTime SignTime {get;set;}

           /// <summary>
           /// Desc:状态;0-拟定;1-谈判;2-已签约;3-签约失败;4-已放款;5-审批未通过;6-客户退单
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="state")]           
           public short State {get;set;}

    }
}
