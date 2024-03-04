using CRM.Models.View;
using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class CustomerInfoController : BaseController
    {
        private ICustomerInfoService service;

        public CustomerInfoController(ICustomerInfoService service)
        {
            this.service = service;
        }

        [HttpGet("{customerId}")]
        public CustomerInfoViewModel GetDetail(ulong customerId)
        {
            return service.GetDetail(customerId);
        }
    }
}
