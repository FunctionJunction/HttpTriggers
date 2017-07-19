using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure.Documents.Client;
using System.Collections.Generic;

namespace Triggers.Http
{
    public static class CRUDTriggers
    {
        [FunctionName("DocumentDbGet")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get")]HttpRequestMessage req, TraceWriter log, [DocumentDB("PantryApp", "pantrylists")]IEnumerable<Pantry> pantrys)
        {
            var getstuff = pantrys.Where(x => x.PantryName == "test2");

            return req.CreateResponse(HttpStatusCode.OK);
        }

        public class Pantry
        {
            public string PantryName { get; set; }
            public string UserId { get; set; }
        }
    }
}