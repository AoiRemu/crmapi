namespace CRM.Models.View
{
    public class AccountRequest
    {
    }

    public class AccountData
    {
        public string Name { get; set; } = string.Empty;

        public ulong AccountId { get; set; }

        public string Account { get; set; } = string.Empty;

        public string RoleString { get; set; } = string.Empty;

        public List<string> Roles => RoleString.Split(',').ToList();
    }
}
