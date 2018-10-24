using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace StripeWebhook.TableEntities
{
    public class ExceptionLogEntity : TableEntity
    {
        public ExceptionLogEntity(string rowKey)
        {
            this.PartitionKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N"));
            this.RowKey= rowKey;
        }

        public ExceptionLogEntity() { }

        public string Message;
    }
}