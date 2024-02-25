using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class AccountMainService : IAccountMainService
    {
        private AccountMainRepository repository;
        public AccountMainService(AccountMainRepository repository)
        {
            this.repository = repository;
        }
    }
}
