using CRM.Services;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace CRM.Controllers
{
    public class DemoController : BaseController
    {
        private DemoService _demoService;

        public DemoController(ISqlSugarClient sqlSugarClient)
        {
            _demoService = new DemoService(sqlSugarClient);
        }

        [HttpGet]
        public string CreateModelFiles()
        {
            _demoService.CreateModelFiles();
            return "ok";
        }

        [HttpGet]
        public string CreateCodeFiles()
        {
            _demoService.CreateCodeFiles();
            return "ok";
        }
    }
}
