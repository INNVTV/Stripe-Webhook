using System;
using Stripe;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StripeWebhook.Models;
using StripeWebhook.TableEntities;
using Microsoft.WindowsAzure.Storage; 
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace StripeWebhook.Controllers
{
    [Route("/")]
    [ApiController]
    public class StripeController : ControllerBase
    {

        // POST api/values
        [HttpPost]
        public ActionResult Post()
        {
            // Connect to storage
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(AppSettings.ConnectionString);

            try{

                // Unpack the Stripe Event
                var json = new StreamReader(HttpContext.Request.Body).ReadToEndAsync().Result;
                var stripeEvent = Stripe.EventUtility.ParseEvent(json);


                // Connect to Message Queue
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference(AppSettings.QueueName);
                queue.CreateIfNotExistsAsync();

                // Connect to LogsTable
                CloudTableClient logsTableClient = storageAccount.CreateCloudTableClient();
                CloudTable logsTable = logsTableClient.GetTableReference(AppSettings.StripeEventLogTableName);
                logsTable.CreateIfNotExistsAsync();


                //string stripeEventId = stripeEvent.Type = EventUtility.;

                // Ensure idempotency (Has this already been logged?)
                //https://stripe.com/docs/api/idempotent_requests?lang=curl

                // We only focus on the events we care about, the remainder are logged for future reference:
                switch(stripeEvent.Type)
                {
                    case Stripe.Events.CustomerCreated:
                        break;
                    case Stripe.Events.ChargeSucceeded:
                        break;
                    case Stripe.Events.ChargeFailed:
                        break;
                    default:
                        break;
                }

                // Send into message queue:
                // Create a message and add it to the queue.
                    var queueMessage = new QueueMessage{
                        Id = stripeEvent.Id,
                    };

                    var messageAsJson = JsonConvert.SerializeObject(queueMessage);
                    CloudQueueMessage message = new CloudQueueMessage(messageAsJson);
                    queue.AddMessageAsync(message);

                // Log processing of this event: 
                var eventLogEntity = new EventLogEntity("");
                TableOperation insertOperation = TableOperation.Insert(eventLogEntity);
                logsTable.ExecuteAsync(insertOperation);

                // Return status code 200
                return Ok();

            }
            catch(Exception e)
            {
                // Connect to ExceptionsTable
                CloudTableClient exceptionsTableClient = storageAccount.CreateCloudTableClient();
                CloudTable exceptionsTable = exceptionsTableClient.GetTableReference(AppSettings.ExceptionLogTableName);
                exceptionsTable.CreateIfNotExistsAsync();

                // Log the exception:
                var exceptionLogEntity = new ExceptionLogEntity(""){
                        Message = e.Message
                    };
                TableOperation insertOperation = TableOperation.Insert(exceptionLogEntity);
                exceptionsTable.ExecuteAsync(insertOperation);


                // Return status code 400:
                return BadRequest();
            }     
        }
    }
}
