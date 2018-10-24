using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace StripeWebhook.TableEntities
{
    public class EventLogEntity : TableEntity
    {
        public EventLogEntity(string id)
        {
            this.PartitionKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N"));
            Id = id;
        }

        public EventLogEntity() { }

        public string Id
        {
            get { return RowKey; }
            set { RowKey = value; }
        }
        public string Type;
    }
}