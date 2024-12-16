using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace MarshallBensonMusic.RetrieveBands
{
    public class dboBANDS
    {
        private readonly ILogger _logger;

        public dboBANDS(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<dboBANDS>();
        }

        [Function("dboBANDS")]
        public static async Task<List<BandItem>> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "bands")]
     HttpRequestData req,
    [SqlInput("select * from [dbo].[BANDS]",
         "SqlConnectionString")]
     IAsyncEnumerable<BandItem> bandItems)
        {
            var enumerator = bandItems.GetAsyncEnumerator();
            var bandList = new List<BandItem>();
            while (await enumerator.MoveNextAsync())
            {
                bandList.Add(enumerator.Current);
            }
            await enumerator.DisposeAsync();
            return bandList;
        }
    }

    public class BandItem
    {
        public int ID { get; set; }
        public string? NAME { get; set; }

    }
}
