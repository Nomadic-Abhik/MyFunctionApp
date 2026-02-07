using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MyFunctionApp;

public class  GetFunction
{
    
    [Function("GetFunction")]
    public async Task<IActionResult> RunGetFunction(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
    {
       
        // Safely read the "name" query value (handles nullable Query and missing key)
        string? name = null;
        if (req?.Query != null && req.Query.TryGetValue("name", out var nameValues))
        {
            name = nameValues.FirstOrDefault();
        }

        // Default when name is null
        name ??= "Abhik";

        string responseMessage = string.IsNullOrEmpty(name)
            ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            : $"Hello Miss, {name}. This HTTP triggered function executed successfully.";

        // Use await to satisfy the async method warning while returning the message.
        return new OkObjectResult(await Task.FromResult(responseMessage));
    }
}
