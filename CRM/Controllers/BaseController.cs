using CRM.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private AccountData _accountData;

        /// <summary>
        /// 当前操作人
        /// </summary>
        protected AccountData AccountData => _accountData;
        
    }
}
