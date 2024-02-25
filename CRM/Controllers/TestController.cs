using CRM.Services.Interfaces;

namespace CRM.Controllers
{
    public class TestController : BaseController
    {
        private ITestService service;

        public TestController(ITestService service)
        {
            this.service = service;
        }
    }
}
