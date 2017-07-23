using Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What sort of message would you like to send?");
            Console.WriteLine("1. Storage queue");
            Console.WriteLine("x. Exit");

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "1")
                {
                    var storageAccount = CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["storageConnectionString"]);
                    var queueClient = storageAccount.CreateCloudQueueClient();
                    var queueReference = queueClient.GetQueueReference(System.Configuration.ConfigurationManager.AppSettings["storageQueue"]);
                    queueReference.CreateIfNotExists();
                    queueReference.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(new SendEmailMessage
                    {
                        Subject = "Hello Function Junctioners",
                        Body = "Welcome to Function Junction",
                        DestinationAddress = "fans@functionjunction.com"
                    })));
                }
            }
        }
    }
}
