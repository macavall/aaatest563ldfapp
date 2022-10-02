using System;
using System.Collections;
using System.Text;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace aaatest563ldfapp
{
    public class partitionedqueue
    {
        [FunctionName("partitionedqueue")]
        public void Run([ServiceBusTrigger("partitionedqueue", AutoComplete = true, Connection = "sbconnstring", IsSessionsEnabled = false)]Message myQueueItem,
            //Microsoft.Azure.Amqp.Framing.ApplicationProperties ApplicationProperties,
            //ApplicationProperties props,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem.PartitionKey} "); // {Encoding.Default.GetString(myQueueItem)}");
            var delay = Convert.ToInt32(Environment.GetEnvironmentVariable("Delay"));
            if (delay > 0)
            {
                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
