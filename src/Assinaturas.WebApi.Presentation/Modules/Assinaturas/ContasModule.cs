using Assinaturas.Application.Assinaturas.CriarConta;
using Assinaturas.Application.Assinaturas.ObterContaPorId;
using Assinaturas.Application.Assinaturas.ObterContas;
using Assinaturas.Application.Assinaturas.RemoverConta;
using Assinaturas.WebApi.Presentation.Core;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        app.MapGet(ROUTE, async (ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new ObterContasRequest(), cancellationToken);

            return Results.Ok(result.Contas);
        })
        .WithName(RouteNames.GetContas);


        app.MapGet($"{ROUTE}/{{id:Guid}}", async(Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new ObterContaPorIdRequest(id), cancellationToken);

            return result.Conta is null ? Results.NotFound() : Results.Ok(result.Conta);
        })
        .WithName(RouteNames.GetContaById);


        app.MapPost(ROUTE, async ([FromBody]CriarContaRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(request, cancellationToken);

            return result.Match(
                response => Results.CreatedAtRoute(RouteNames.GetContaById, new { id = result.Value.Conta.Id }, result.Value.Conta),
                error => ResultHelper.Problem(error));
        })
        .WithName(RouteNames.PostContas);


        app.MapPut(ROUTE, (object conta, ISender sender, CancellationToken cancellationToken) =>
        {
            return Results.Ok(conta);
        })
        .WithName(RouteNames.PutContas);


        app.MapDelete($"{ROUTE}/{{id:Guid}}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            await sender.Send(new RemoverContaRequest(id), cancellationToken);

            return Results.NoContent();
        })
        .WithName(RouteNames.DeleteContas);
    }
}
