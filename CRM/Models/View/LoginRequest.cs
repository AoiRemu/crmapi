namespace CRM.Models.View
{
    public class LoginRequest
    {
        public string Account { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public UserInfo? UserInfo { get; set; }

        public string Token { get; set; } = string.Empty;
    }

    public class UserInfo
    {
        public ulong Id { get; set; }
        public string Account { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public IEnumerable<string>? Roles { get; set; }
    }
}
