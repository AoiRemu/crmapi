using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class AccountMainController : BaseController
    {
        private IAccountMainService service;

        public AccountMainController(IAccountMainService service)
        {
            this.service = service;
        }
    }
}
