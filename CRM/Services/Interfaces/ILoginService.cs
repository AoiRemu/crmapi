using CRM.Common.Helpers;
using CRM.Models.View;
using CRM.Repositories;

namespace CRM.Services.Interfaces
{
    public interface ILoginService : IScopedService
    {
        public ResultInfo Login(LoginRequest request);
    }
}
