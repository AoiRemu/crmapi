using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class AccountRoleService : IAccountRoleService
    {
        private AccountRoleRepository repository;
        public AccountRoleService(AccountRoleRepository repository)
        {
            this.repository = repository;
        }
    }
}
