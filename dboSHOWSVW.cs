using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace MarshallBensonMusic.Shows
{
    public class dboSHOWSVW
    {
        private readonly ILogger _logger;

        public dboSHOWSVW(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<dboSHOWSVW>();
        }

        [Function("dboSHOWSVW")]
        public IEnumerable<ShowItem> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequestData req,
            [SqlInput("SELECT * FROM [dbo].[SHOWS_VW]",
            "SqlConnectionString")] IEnumerable<ShowItem> showItems)
        {
            _logger.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return showItems;
        }
    }
}
