using Assinaturas.Application.Enderecos.PesquisarPorCep;
using Assinaturas.WebApi.Presentation.Core;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Assinaturas.WebApi.Presentation.Core.Constants;

namespace Assinaturas.WebApi.Presentation.Modules.Enderecos;

public class EnderecosModule : ICarterModule
{
    private const string BASE_ROUTE = "enderecos";
    private static readonly string ROUTE = $"{ROUTE_PREFIX}{BASE_ROUTE}";

    private static class RouteNames
    {
        public const string PesquisarPorCep = "PesquisarPorCep";
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(ROUTE, async ([FromQuery]string cep, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new PesquisarPorCepRequest(cep), cancellationToken);

            return result.Match(
                response => !response.Endereco.Vazio ? Results.Ok(response.Endereco) : Results.NotFound(),
                _ => ResultHelper.Problem(result.Error)
            );
        })
        .WithName(RouteNames.PesquisarPorCep);
    }
}
