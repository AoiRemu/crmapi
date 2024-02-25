using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///用户权限表
    ///</summary>
    [SugarTable("account_role")]
    public partial class AccountRoleModel
    {
           public AccountRoleModel(){


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
           /// Desc:角色;1-超级管理员;2-管理员;3-员工
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="role")]           
           public short Role {get;set;}

           /// <summary>
           /// Desc:账户id
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="account_id")]           
           public ulong AccountId {get;set;}

    }
}
