using Microsoft.WindowsAzure.Storage.Table;

namespace StripeWebhook.Models
{
    public class ExceptionLogEntity : TableEntity
    {
        public ExceptionLogEntity(string Id)
        {
            this.PartitionKey = Id;
            this.RowKey= "";
        }

        public ExceptionLogEntity() { }

        public string Message;
    }
}