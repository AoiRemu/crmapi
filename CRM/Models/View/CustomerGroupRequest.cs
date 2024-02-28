using Models;

namespace CRM.Models.View
{
    public class CustomerGroupRequest : PageRequest
    {
        public string? Name { get; set; }
    }

    public class CustomerGroupViewModel
    {
        public CustomerGroupViewModel() { }

        public CustomerGroupViewModel(CustomerGroupModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Ctime = model.Ctime;
            Utime = model.Utime;
            ParentId = model.ParentId;
        }

        public CustomerGroupModel ToDBModel()
        {
            return new CustomerGroupModel()
            {
                Id = Id,
                Name = Name,
                Ctime = Ctime,
                Utime = Utime,
                ParentId = ParentId
            };
        }

        /// <summary>
        /// Desc:主键Id
        /// Default:
        /// Nullable:False
        /// </summary>           
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
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Desc:父分组id;0-初始分组
        /// Default:0
        /// Nullable:False
        /// </summary>
        public ulong ParentId { get; set; }
    }
}
