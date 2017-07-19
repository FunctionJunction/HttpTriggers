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
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get")]HttpRequestMessage req, TraceWriter log, [DocumentDB("DbName", "CollectionName")]IEnumerable<ModelToReadFromDb> items)
        {
            //Can perform operations on the "items" variable, which will be the result of the table/collection you specify

            return req.CreateResponse(HttpStatusCode.OK);
        }

        public class ModelToReadFromDb
        {
            public string Id { get; set; }
        }
    }
}