using Models;
using SqlSugar;

namespace CRM.Models.View
{

    #region 列表搜索
    public class CustomerSearchReuqest : PageRequest
    {
        public string? Name { get; set; }

        public short? State { get; set; }

        public ulong? GroupId { get; set; }
    }

    public class CustomerSearchViewModel
    {
        public string Name { get; set;} = string.Empty;
        public ulong Id { get; set; }
        public short FollowState { get; set; }
        public DateTime Ctime { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string FollowAccount { get; set; } = string.Empty;
        public ulong FollowAccountId { get; set; }
        public short Level { get; set; }
        public short State { get; set; }
        public ulong GroupId { get; set; }
        public List<CustomerTagViewModel> Tags { get; set; } = new List<CustomerTagViewModel>();
        public string Qualification { get; set; } = string.Empty;
        public DateTime? NextFollowTime { get; set; }
    }

    #endregion

    #region 添加客户

    public class CustomerAddRequest
    {
        public CustomerMainAddViewModel Main { get; set; }

        public CustomerInfoAddViewModel Info { get; set; }
    }

    public class CustomerMainAddViewModel
    {
        public CustomerMainAddViewModel(){}
        public CustomerMainAddViewModel(CustomerMainModel model)
        {
            Name = model.Name;
            Gender = model.Gender;
            Source = model.Source;
            GroupId = model.GroupId;
            Level = model.Level;
            Phone = model.Phone;
            Telphone = model.Telphone;
            Qq = model.Qq;
            Wechat = model.Wechat;
            County  = model.County;
            Address = model.Address;
            Qualification = model.Qualification;
        }

        public CustomerMainModel ToDBModel()
        {
            return new CustomerMainModel()
            {
                Name = Name,
                Gender = Gender,
                Source = Source,
                GroupId = GroupId,
                Level = Level,
                Phone = Phone,
                Telphone = Telphone,
                Qq = Qq,
                Wechat = Wechat,
                County = County,
                Address = Address,
                Qualification = Qualification,
            };
        }

        /// <summary>
        /// Desc:名字
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Desc:性别;0-未知;1-男;2-女
        /// Default:0
        /// Nullable:False
        /// </summary>
        public short Gender { get; set; }

        /// <summary>
        /// Desc:来源
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Desc:分组id
        /// Default:0
        /// Nullable:False
        /// </summary>
        public ulong GroupId { get; set; }

        /// <summary>
        /// Desc:星级
        /// Default:0
        /// Nullable:False
        /// </summary>
        public short Level { get; set; }

        /// <summary>
        /// Desc:手机
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Desc:座机
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Telphone { get; set; }

        /// <summary>
        /// Desc:QQ
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Qq { get; set; }

        /// <summary>
        /// Desc:微信
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Wechat { get; set; }

        /// <summary>
        /// Desc:地区
        /// Default:
        /// Nullable:False
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Desc:地址
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Desc:资质
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Qualification { get; set; }
    }

    public class CustomerInfoAddViewModel
    {

        public CustomerInfoAddViewModel() { }

        public CustomerInfoAddViewModel(CustomerInfoModel model)
        {
            CustomerId = model.CustomerId;
            Birthday = model.Birthday;
            Position = model.Position;
            Industry = model.Industry;
            WorkAddress = model.WorkAddress;
            NetAddress = model.NetAddress;
            Description = model.Description;
        }

        public CustomerInfoModel ToDBModel()
        {
            return new CustomerInfoModel()
            {
                CustomerId = CustomerId,
                Birthday = Birthday,
                Position = Position,
                Industry = Industry,
                WorkAddress = WorkAddress,
                NetAddress = NetAddress,
                Description = Description,
            };
        }

        public ulong CustomerId { get; set; }

        /// <summary>
        /// Desc:生日
        /// Default:1970-01-01 00:00:00
        /// Nullable:False
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Desc:职务
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Desc:行业
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// Desc:工作单位
        /// Default:
        /// Nullable:False
        /// </summary>
        public string WorkAddress { get; set; }

        /// <summary>
        /// Desc:网址
        /// Default:
        /// Nullable:False
        /// </summary>
        public string NetAddress { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Description { get; set; }
    }

    #endregion

    #region 批量分组

    public class CustomerBatchGroupRequest
    {
        public List<ulong> CustomerIdList { get; set; } = new List<ulong>();

        public ulong GroupId { get; set; }
    }

    #endregion
}
