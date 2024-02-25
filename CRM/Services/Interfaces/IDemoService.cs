using CRM.Common.Helpers;

namespace CRM.Services.Interfaces
{
    public interface IDemoService : IScopedService
    {
        public void CreateModelFiles();
    }
}
