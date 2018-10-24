using Microsoft.WindowsAzure.Storage.Table;

namespace StripeWebhook.TableEntities
{
    public class EventLogEntity : TableEntity
    {
        public EventLogEntity(string Id)
        {
            this.PartitionKey = RowKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N"));
            this.RowKey= "";
        }

        public EventLogEntity() { }

        public string Type;
    }
}