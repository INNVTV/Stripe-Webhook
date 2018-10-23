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
        public ActionResult Post(Stripe.Event stripeEvent)
        {
            try{

                // Unpack the stripe event
                string stripeEventId = stripeEvent.Id;

                // Ensure idempotency (Has this already been logged?)

                switch(stripeEvent.Type)
                {
                    case "invoice.payment_succeeded":
                        break;
                    case "invoice...d":
                        break;
                    default:
                        break;
                }

                // Log into message queue:

                // Return status code 200
                return Ok();

            }
            catch(Exception e)
            {
                // Log the exception:
                var exceptionMessage=e.Message;

                // Return status code 400:
                return BadRequest();
            }     
        }
    }
}
