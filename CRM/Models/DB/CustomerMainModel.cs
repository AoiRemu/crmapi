using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///客户主表
    ///</summary>
    [SugarTable("customer_main")]
    public partial class CustomerMainModel
    {
           public CustomerMainModel(){


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
           /// Desc:名字
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="name")]           
           public string Name {get;set;}

           /// <summary>
           /// Desc:性别;0-未知;1-男;2-女
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="gender")]           
           public short Gender {get;set;}

           /// <summary>
           /// Desc:来源
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="source")]           
           public string Source {get;set;}

           /// <summary>
           /// Desc:分组id
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="group_id")]           
           public ulong GroupId {get;set;}

           /// <summary>
           /// Desc:星级
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="level")]           
           public short Level {get;set;}

           /// <summary>
           /// Desc:跟进人
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="follow_account")]           
           public string FollowAccount {get;set;}

           /// <summary>
           /// Desc:跟进人id
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="follow_account_id")]           
           public ulong FollowAccountId {get;set;}

           /// <summary>
           /// Desc:手机
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="phone")]           
           public string Phone {get;set;}

           /// <summary>
           /// Desc:座机
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="telphone")]           
           public string Telphone {get;set;}

           /// <summary>
           /// Desc:QQ
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="qq")]           
           public string Qq {get;set;}

           /// <summary>
           /// Desc:微信
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="wechat")]           
           public string Wechat {get;set;}

           /// <summary>
           /// Desc:地区
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="county")]           
           public string County {get;set;}

           /// <summary>
           /// Desc:地址
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="address")]           
           public string Address {get;set;}

           /// <summary>
           /// Desc:资质
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="qualification")]           
           public string Qualification {get;set;}

           /// <summary>
           /// Desc:状态;0-新入库;1-已认领;2-放弃;3-已成交;
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="state")]           
           public short State {get;set;}

           /// <summary>
           /// Desc:是否删除;0-正常，1-删除
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="isdel")]           
           public short Isdel {get;set;}

           /// <summary>
           /// Desc:是否删除;0-正常，1-删除
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName = "follow_state")]
           public short FollowState { get; set; }
    }
}
