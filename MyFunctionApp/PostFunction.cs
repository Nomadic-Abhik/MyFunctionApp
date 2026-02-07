using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;


namespace MyFunctionApp;

public class PostFunction
{

    [Function("PostFunction")]
    public async Task<IActionResult> RunPostFunction(
            [HttpTrigger(AuthorizationLevel.Function, "Post", Route = null)] HttpRequest req)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        requestBody = requestBody ?? "Boni";
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        string name = data?.name;

        string responseMessage = string.IsNullOrEmpty(name)
            ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            : $"Hello Miss, {name}. This HTTP triggered function executed successfully";

        return new OkObjectResult(responseMessage);

    }
}
