using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///用户主表
    ///</summary>
    [SugarTable("account_main")]
    public partial class AccountMainModel
    {
           public AccountMainModel(){


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
           /// Desc:账户
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="account")]           
           public string Account {get;set;}

           /// <summary>
           /// Desc:名字
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="name")]           
           public string Name {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="password")]           
           public string Password {get;set;}

           /// <summary>
           /// Desc:是否删除;0-正常，1-删除
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="isdel")]           
           public short Isdel {get;set;}

    }
}
