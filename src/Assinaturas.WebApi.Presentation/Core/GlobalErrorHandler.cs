using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Assinaturas.WebApi.Presentation.Core;

internal static class GlobalErrorHandler
{
    public static void HandleError(IApplicationBuilder appBuilder)
        => appBuilder.Run(async context =>
        {
            var excHandler = context.Features.Get<IExceptionHandlerFeature>();
            var error = excHandler?.Error;

            if (error is not null)
            {
                if (error is ValidationException)
                {
                    await Results
                            .ValidationProblem(((ValidationException)error).Errors.ToDictionary(k => k.PropertyName, x => new string[] { x.ErrorCode }))
                            .ExecuteAsync(context);

                    return;
                }
            }
            await Results.Problem().ExecuteAsync(context);
        });
}