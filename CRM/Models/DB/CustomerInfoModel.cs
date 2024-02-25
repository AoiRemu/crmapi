using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///客户详情表
    ///</summary>
    [SugarTable("customer_info")]
    public partial class CustomerInfoModel
    {
           public CustomerInfoModel(){


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
           /// Desc:生日
           /// Default:1970-01-01 00:00:00
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="birthday")]           
           public DateTime Birthday {get;set;}

           /// <summary>
           /// Desc:职务
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="position")]           
           public string Position {get;set;}

           /// <summary>
           /// Desc:行业
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="industry")]           
           public string Industry {get;set;}

           /// <summary>
           /// Desc:工作单位
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="work_address")]           
           public string WorkAddress {get;set;}

           /// <summary>
           /// Desc:网址
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="net_address")]           
           public string NetAddress {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="description")]           
           public string Description {get;set;}

    }
}
