using Models;

namespace CRM.Models.View
{
    public class TagRequest : PageRequest
    {
        public string? Name { get; set; }

        public ulong? GroupId { get; set; }
    }

    public class TagViewModel
    {
        public TagViewModel() { }

        public TagViewModel(TagModel model)
        {
            Id = model.Id;
            Name = model.Name;
            GroupId = model.GroupId;
            Ctime = model.Ctime;
            Utime = model.Utime;
        }

        public TagModel ToDBModel()
        {
            return new TagModel()
            {
                Ctime = Ctime,
                Utime = Utime,
                GroupId = GroupId,
                Name = Name,
                Id = Id
            };
        }

        public ulong Id { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime Ctime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>
        public DateTime Utime { get; set; }

        /// <summary>
        /// Desc:名称
        /// Default:0
        /// Nullable:False
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Desc:标签分组id
        /// Default:0
        /// Nullable:False
        /// </summary>
        public ulong GroupId { get; set; }
    }
}
