using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///客户标签表
    ///</summary>
    [SugarTable("customer_tag")]
    public partial class CustomerTagModel
    {
           public CustomerTagModel(){


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
           /// Desc:标签id
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="tag_id")]           
           public ulong TagId {get;set;}

           /// <summary>
           /// Desc:客户id
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="customer_id")]           
           public ulong CustomerId {get;set;}

    }
}
