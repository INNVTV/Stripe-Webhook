using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using StripeWebhook.Models;

namespace StripeWebhook
{
    public static class Settings
    {
        public static void ApplyAppSettings()
        {
            //Get configuration from Docker/Compose (via .env and appsettings.json)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables(); //<-- Allows for Docker Env Variables

            IConfigurationRoot configuration = builder.Build();

            var _storageName = configuration["Storage:Name"];
            var _storageKey = configuration["Storage:Key"];

            var _queuesMessages = configuration["Queues:Messages"];

            var _tablesLogs = configuration["Tables:Logs"];
            var _tablesExceptions = configuration["Tables:Exceptions"];

            AppSettings.StorageName = _storageName;
            AppSettings.StorageKey = _storageKey;

            AppSettings.QueueName = _queuesMessages;
            AppSettings.QueueAddress = string.Concat("https://", _storageName, ".queue.core.windows.net/", _queuesMessages);
            
            AppSettings.StripeEventLogTableName = _tablesLogs;
            AppSettings.ExceptionLogTableName = _tablesExceptions;

            AppSettings.ConnectionString = string.Concat("DefaultEndpointsProtocol=https;AccountName=", _storageName ,";AccountKey=", _storageKey);
        }
    }
}