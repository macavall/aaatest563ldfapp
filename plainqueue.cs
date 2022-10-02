using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace aaatest563ldfapp
{
    public class plainqueue
    {
        [FunctionName("plainqueue")]
        public void Run([ServiceBusTrigger("plainqueue", AutoComplete = true, Connection = "sbconnstring", IsSessionsEnabled = false)]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var delay = Convert.ToInt32(Environment.GetEnvironmentVariable("Delay"));
            if (delay > 0)
            {
                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
