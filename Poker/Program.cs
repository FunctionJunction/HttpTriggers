using Common;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What sort of message would you like to send?");
            Console.WriteLine("1. Storage queue");
            Console.WriteLine("2. Service Bus queue");
            Console.WriteLine("x. Exit");

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "1")
                {
                    var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["storageConnectionString"]);
                    var queueClient = storageAccount.CreateCloudQueueClient();
                    var queueReference = queueClient.GetQueueReference(ConfigurationManager.AppSettings["storageQueue"]);
                    queueReference.CreateIfNotExists();
                    queueReference.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(new SendEmailMessage
                    {
                        Subject = "Hello Function Junctioners",
                        Body = "Welcome to Function Junction",
                        DestinationAddress = "fans@functionjunction.com"
                    })));
                }
                if (line == "2")
                {
                    var client = QueueClient.CreateFromConnectionString(ConfigurationManager.AppSettings["serviceBusAccount"],
                        ConfigurationManager.AppSettings["storageQueue"]);
                    client.Send(new BrokeredMessage(new SendEmailMessage
                    {
                        Subject = "Hello Function Junctioners",
                        Body = "Welcome to Function Junction",
                        DestinationAddress = "fans@functionjunction.com"
                    }));
                }
                if (line == "x")
                    return;
            }
        }
    }
}
