using CRM.Common.Helpers;
using CRM.Models.Enums;
using CRM.Models.View;
using CRM.Repositories;
using CRM.Services.Interfaces;
using Models;
using Newtonsoft.Json;

namespace CRM.Services
{
    public class LoginService : ILoginService
    {
        private AccountMainRepository accountMainRepository;
        private AccountRoleRepository accountRoleRepository;
        private IConfiguration configuration;
        public LoginService(AccountMainRepository accountMainRepository, AccountRoleRepository accountRoleRepository, IConfiguration configuration)
        {
            this.accountMainRepository = accountMainRepository;
            this.accountRoleRepository = accountRoleRepository;
            this.configuration = configuration;
        }

        public ResultInfo Login(LoginRequest request)
        {
            request.Password = request.Password.ToMD5String();
            var account = accountMainRepository.GetLoginAccount(request.Account, request.Password);
            if(account == null)
            {
                return ResultInfo.Fail<LoginResponse>("用户名或者密码错误");
            }

            var roles = accountRoleRepository.GetAccountRoles(account.Id);
            if(roles.Count == 0)
            {
                return ResultInfo.Fail<LoginResponse>("此用户无权限，请联系管理员");
            }

            var tokenHeler = new TokenHelper(configuration);
            var jwtUser = new JwtUser()
            {
                Id = account.Id.ToString(),
                Name = account.Name,
                Account = account.Account,
                Roles = roles.Select(a => Enum.GetName((AccountRoleEnum)a.Role) ?? "")
            };

            var token = tokenHeler.GenerateToken(jwtUser);
            var loginResponse = new LoginResponse()
            {
                Token = token,
                UserInfo = new UserInfo()
                {
                    Id = account.Id,
                    Account = account.Account,
                    Name = account.Name,
                    Roles = jwtUser.Roles
                }
            };

            var result = ResultInfo.Success("登录成功", loginResponse);
            return result;
        }
    }
}
