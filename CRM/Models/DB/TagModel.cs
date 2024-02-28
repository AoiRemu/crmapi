using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///标签表
    ///</summary>
    [SugarTable("tag")]
    public partial class TagModel
    {
        public TagModel()
        {


        }
        /// <summary>
        /// Desc:主键Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public ulong Id { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "ctime")]
        public DateTime Ctime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "utime")]
        public DateTime Utime { get; set; }

        /// <summary>
        /// Desc:名称
        /// Default:0
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Desc:标签分组id
        /// Default:0
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "group_id")]
        public ulong GroupId { get; set; }

        /// <summary>
        /// Desc:是否删除
        /// Default:0
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "isdel")]
        public short Isdel { get; set; }
    }
}
