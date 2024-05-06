
using MinimalApiTemplate.Application.Wrappers;

namespace MinimalApiTemplate.Api.Endpoints.v1
{
    public static class DocumentEndpoint
    {
        public static void MapDocumentEndpoint(this IEndpointRouteBuilder routeBuilder)
        {
            var app = routeBuilder.MapGroup("/Document")
            .WithTags("Document")
            .MapToApiVersion(1)
            .WithOpenApi();

            app.MapGet("GetErrorsCode", () =>
            {

                return Enum
                .GetValues(typeof(ErrorCode))
                .Cast<ErrorCode>()
                .ToDictionary(t => ((int)t).ToString(), t => t.ToString());

            });
        }



    }
}

