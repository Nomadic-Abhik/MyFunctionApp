using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TimerTrigger
{
    public  class TimerFunc
    {
        [FunctionName("TimerFunc")]
        public async Task<IActionResult> Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            string responseMessage = $"Hello This Timmer triggered function executed successfully st {DateTime.Now}.";

            // Use await to satisfy the async method warning while returning the message.
            return new OkObjectResult(await Task.FromResult(responseMessage));
        }
    }
}
