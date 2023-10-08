using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using static Assinaturas.WebApi.Presentation.Core.Constants;

namespace Assinaturas.WebApi.Presentation.Modules.Assinaturas;

public class ContasModule : ICarterModule
{
    private const string BASE_ROUTE = "contas";
    private static readonly string ROUTE = $"{ROUTE_PREFIX}{BASE_ROUTE}";

    private static class RouteNames
    {
        public const string GetContas = "GetContas";
        public const string GetContaById = "GetContaById";
        public const string PostContas = "PostContas";
        public const string PutContas = "PutContas";
        public const string DeleteContas = "DeleteContas";
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(ROUTE, (CancellationToken cancellationToken) =>
        {
            return Results.Ok(new string[] { "X", "Y", "Z" });
        })
        .WithName(RouteNames.GetContas);


        app.MapGet($"{ROUTE}/{{id:Guid}}", (Guid id, CancellationToken cancellationToken) =>
        {
            return Results.Ok(new { conta = "X" });
        })
        .WithName(RouteNames.GetContaById);


        app.MapPost(ROUTE, (object conta, CancellationToken cancellationToken) =>
        {
            var newlyCreatedFakeContaId = Guid.NewGuid();

            return Results.CreatedAtRoute(RouteNames.GetContaById, new { id = newlyCreatedFakeContaId }, new { conta = "X" });
        })
        .WithName(RouteNames.PostContas);


        app.MapPut(ROUTE, (object conta, CancellationToken cancellationToken) =>
        {
            return Results.Ok(conta);
        })
        .WithName(RouteNames.PutContas);


        app.MapDelete($"{ROUTE}/{{id:Guid}}", (Guid id, CancellationToken cancellationToken) =>
        {
            return Results.NoContent();
        })
        .WithName(RouteNames.DeleteContas);
    }
}
