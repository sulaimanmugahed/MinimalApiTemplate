using Asp.Versioning;
using Asp.Versioning.Builder;
using MinimalApiTemplate.Api.Endpoints.v1;
using MinimalApiTemplate.Api.Endpoints.v2;

namespace MinimalApiTemplate.Api.Endpoints
{
    public static class BaseEndpoint
    {
        public static void MapAppEndpoints(this IEndpointRouteBuilder app)
        {
            ApiVersionSet apiVersionSet = app.NewApiVersionSet()
                .HasDeprecatedApiVersion(new ApiVersion(1))
                .HasApiVersion(new ApiVersion(2))
                .ReportApiVersions()
                .Build();

            var root = app.MapGroup("api/v{apiVersion:apiVersion}")
                .WithApiVersionSet(apiVersionSet);

            root.MapAccountEndpointV1();
            root.MapProductsEndpointV1();
            root.MapProductsEndpointV2();
            
            root.MapDocumentEndpoint();
        }
    }
}
