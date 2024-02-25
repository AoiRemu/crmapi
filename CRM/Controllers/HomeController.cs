using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class HomeController : BaseController
    {
        private ILoginService _loginService;

        public HomeController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ResultInfo Login(LoginRequest request)
        {
            return _loginService.Login(request);
        }
    }
}
