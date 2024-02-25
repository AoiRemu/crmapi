using CRM.Services.Interfaces;
using CRM.Repositories;

namespace CRM.Services
{
    public class TestService : ITestService
    {
        private TestRepository repository;
        public TestService(TestRepository repository)
        {
            this.repository = repository;
        }
    }
}
