namespace StripeWebhook.Models
{
    public static class AppSettings
    {
        public static string StorageName { get; set; }
        public static string StorageKey { get; set; }
        public static string QueueName { get; set; }
        public static string QueueAddress { get; set; }
        public static string ExceptionLogTableName { get; set; }
        public static string StripeEventLogTableName { get; set; }
        public static string ConnectionString { get; set; }

    }
}