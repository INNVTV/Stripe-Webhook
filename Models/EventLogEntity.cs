using Microsoft.WindowsAzure.Storage.Table;

namespace StripeWebhook.Models
{
    public class EventLogEntity : TableEntity
    {
        public EventLogEntity(string Id)
        {
            this.PartitionKey = Id;
            this.RowKey= "";
        }

        public EventLogEntity() { }

        public string Type;
    }
}