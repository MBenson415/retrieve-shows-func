using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MarshallBensonMusic.Shows
{
    public class ReturnShows
    {
        private readonly ILogger _logger;

        public ReturnShows(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ReturnShows>();
        }

        [Function("Shows")]
        public IActionResult Run(
    [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, [SqlInput("SELECT * FROM [dbo].[SHOWS_VW]",
"SqlConnectionString")] IEnumerable<ShowItem> showItems)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(showItems);
        }
    }
}
