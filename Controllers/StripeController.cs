using System;
using Stripe;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StripeWebhook.Controllers
{
    [Route("/")]
    [ApiController]
    public class StripeController : ControllerBase
    {

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
