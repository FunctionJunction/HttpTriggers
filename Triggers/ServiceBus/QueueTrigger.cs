using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Common;


namespace Triggers.ServiceBus
{
    public static class QueueTrigger
    {
        [FunctionName("SendEmail2")]
        public static void SendEmailWithServiceBusQueue([ServiceBusTrigger("emailoutput", Connection = "serviceBusAccount")]SendEmailMessage queueMessage, 
            TraceWriter log)
        {
            log.Info($"C# Service Bus trigger function processed: {queueMessage}");

            //Go send e-mail
        }
    }
}
