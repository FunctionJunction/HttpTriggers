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
        public static void SendEmailWithStorageQueues([QueueTrigger("emailoutput", Connection = "developmentStorage")]string queueMessage, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {queueMessage}");
            var message = JsonConvert.DeserializeObject<SendEmailMessage>(queueMessage);
            //Go send e-mail
        }

        [FunctionName("SendEmail2")]
        public static void SendEmailWithServiceBusQueue([ServiceBusTrigger("emailoutput", Connection = "serviceBusAccount")]SendEmailMessage queueMessage, TraceWriter log)
        {
            log.Info($"C# Service Bus trigger function processed: {queueMessage}");
            
            //Go send e-mail
        }
    }
}
