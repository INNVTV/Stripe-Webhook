/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using Stripe;
using Microsoft.Extensions.Logging;
//using WebApp.Data;
//using Entities;

namespace StripeWebhook.Middleware
{
    public class StripeWebhookHandler
    {
        //private readonly ILogger _log;
        //private readonly ApplicationDataContext _ctx;

        public StripeWebhookHandler(RequestDelegate next)// ), ILoggerFactory logger) //, ApplicationDataContext ctx)
        {
            //_log = logger.CreateLogger<StripeWebhookHandler>();
            //_ctx = ctx;
        }

        public async Task Invoke(HttpContext httpContext)
        {            
            bool handled = true;

            var json = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = Stripe.EventUtility.ParseEvent(json);

            if (true) //if (!_ctx.ServiceEvents.Any(evt => evt.ServiceEventId == stripeEvent.Id))
            {
                switch (stripeEvent.Type)
                {

                    case Stripe.Events.AccountApplicationDeauthorized:
                    case Stripe.Events.AccountExternalAccountCreated:
                    case Stripe.Events.AccountExternalAccountDeleted:
                    case Stripe.Events.AccountExternalAccountUpdated:
                    case Stripe.Events.AccountUpdated:
                        var stripeAccount = Stripe.Mapper<StripeAccount>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case Stripe.Events.ApplicationFeeCreated:
                    case Stripe.Events.ApplicationFeeRefunded:
                    case Stripe.Events.ApplicationFeeRefundUpdated:
                        var fee = Stripe.Mapper<StripeApplicationFee>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.BalanceAvailable:
                        var bal = Stripe.Mapper<StripeBalance>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.BitcoinReceiverCreated:
                    case StripeEvents.BitcoinReceiverFilled:
                    case StripeEvents.BitcoinReceiverTransactionUpdated:
                    case StripeEvents.BitcoinReceiverUpdated:
                        var btcrcv = Stripe.Mapper<StripeReceiver>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.ChargeCaptured:
                    case StripeEvents.ChargeFailed:
                    case StripeEvents.ChargePending:
                    case StripeEvents.ChargeRefunded:
                    case StripeEvents.ChargeSucceeded:
                    case StripeEvents.ChargeUpdated:
                        var charge = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.ChargeDisputeClosed:
                    case StripeEvents.ChargeDisputeCreated:
                    case StripeEvents.ChargeDisputeFundsReinstated:
                    case StripeEvents.ChargeDisputeFundsWithdrawn:
                        var dispute = Stripe.Mapper<StripeDispute>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.CouponCreated:
                    case StripeEvents.CouponDeleted:
                    case StripeEvents.CouponUpdated:
                        var cpn = Stripe.Mapper<StripeCoupon>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.CustomerCreated:
                    case StripeEvents.CustomerDeleted:
                    case StripeEvents.CustomerUpdated:
                        var cst = Stripe.Mapper<StripeCustomer>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.CustomerDiscountCreated:
                    case StripeEvents.CustomerDiscountDeleted:
                    case StripeEvents.CustomerDiscountUpdated:
                        var dsc = Stripe.Mapper<StripeDiscount>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.CustomerSourceCreated:
                        var src = Stripe.Mapper<StripeSource>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.CustomerSubscriptionCreated:
                        break;
                    case StripeEvents.InvoiceCreated:
                        break;
                    case StripeEvents.InvoicePaymentSucceeded:
                        break;
                    case StripeEvents.InvoicePaymentFailed:
                        break;
                    case StripeEvents.Ping:
                        break;
                    case StripeEvents.PlanCreated:
                        break;
                    case StripeEvents.PayoutCreated:
                        break;
                    case StripeEvents.PayoutPaid:
                        break;
                    default:
                        //_log.LogWarning("Received unhandled webhook: {0}", json);
                        handled = false;
                        break;
                }

                if (handled)
                {
                    WebhookEvent evt = new WebhookEvent()
                    {
                        ServiceName = "Stripe",
                        ServiceEventType = stripeEvent.Type.ToString(),
                        ServiceEventId = stripeEvent.Id,
                        Processed = DateTime.Now,
                        EventText = json
                    };

                    //await _ctx.ServiceEvents.AddAsync(evt);

                   //await _ctx.SaveChangesAsync();

                    httpContext.Response.StatusCode = 200;
                }
                else
                    httpContext.Response.StatusCode = 400;
            }
            else
                httpContext.Response.StatusCode = 200;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class StripeWebhookHandlerExtensions
    {
        public static IApplicationBuilder UseStripeWebhookHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StripeWebhookHandler>();
        }
    }
} */