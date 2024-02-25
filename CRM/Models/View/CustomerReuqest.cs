using SqlSugar;

namespace CRM.Models.View
{
    public class CustomerSearchReuqest : PageModel
    {
        public string? Name { get; set; }

        public byte? State { get; set; }

        public ulong? GroupId { get; set; }
    }
}
