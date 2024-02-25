using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///客户分组
    ///</summary>
    [SugarTable("customer_group")]
    public partial class CustomerGroupModel
    {
           public CustomerGroupModel(){


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
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="name")]           
           public string Name {get;set;}

           /// <summary>
           /// Desc:父分组id;0-初始分组
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="parent_id")]           
           public ulong ParentId {get;set;}

    }
}
