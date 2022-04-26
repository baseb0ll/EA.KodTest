using EA.KodTest.Application.Package;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EA.KodTest.Functions
{
    public class GetPackageMeasures
    {
        private readonly IMediator _mediator;

        public GetPackageMeasures(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("GetPackageMeasures")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                string packageNumber = req.Query["packagenumber"];
                var result = await _mediator.Send(new GetPackageMeasuresQuery(packageNumber));

                return new ObjectResult(JsonConvert.SerializeObject(result.Value));
            }
            catch(FluentValidation.ValidationException ex)
            { 
                return new BadRequestObjectResult(ex.Errors);
            }
            
        }
    }
}
