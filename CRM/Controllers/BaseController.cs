using CRM.Common.Helpers;
using CRM.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// 当前操作人
        /// </summary>
        protected AccountData? AccountData 
        { 
            get
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString();
                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var jwtToken = token.Split(" ")[1];
                return TokenHelper.VerifyToken(jwtToken);
            }
        }
    }
}
