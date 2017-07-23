using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Common;

namespace Triggers.StorageQueue
{
    public static class QueueTrigger
    {
        [FunctionName("SendEmail")]        
        public static void Run([QueueTrigger("emailoutput", Connection = "developmentStorage")]string queueMessage, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {queueMessage}");
            var message = JsonConvert.DeserializeObject<SendEmailMessage>(queueMessage);
        }
    }
}
