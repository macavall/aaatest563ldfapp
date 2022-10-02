using System;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace aaatest563ldfapp
{
    public class partitionedsessionedqueue
    {
        [FunctionName("partitionedsessionedqueue")]
        public void Run([ServiceBusTrigger("partitionedsessionedqueue", AutoComplete = true, Connection = "sbconnstring", IsSessionsEnabled = true)]Message myQueueItem,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            //log.LogInformation("================================================");
            log.LogInformation("================================================");
            log.LogInformation($"PARTITION_KEY: {myQueueItem.PartitionKey}");
            log.LogInformation($"SESSION_ID: {myQueueItem.SessionId}");
            log.LogInformation("================================================");
            //log.LogInformation("================================================");

            var delay = Convert.ToInt32(Environment.GetEnvironmentVariable("Delay"));
            if (delay > 0)
            {
                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
