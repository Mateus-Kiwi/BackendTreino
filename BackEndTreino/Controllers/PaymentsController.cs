using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BackEndTreino.Domain.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BackEndTreino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _payment;
        public PaymentsController(IPaymentService payment)
        {
            _payment = payment;

        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<Basket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            return await _payment.CreateOrUpdatePaymentIntent(basketId);
        }
    }
}