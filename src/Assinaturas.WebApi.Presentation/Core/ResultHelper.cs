using Assinaturas.SharedKernel.Results;
using Microsoft.AspNetCore.Http;

namespace Assinaturas.WebApi.Presentation.Core;

public static class ResultHelper
{
    public static IResult Problem(Failure failure)
    {
        if (failure.IsInputValidationError)
            return Results.ValidationProblem(failure.Failures.ToDictionary(k => k.FieldOrProperty, v => new string[] { v.ErrorCode }));

        if (failure.IsBusinessRuleValidationError)
            return Results.ValidationProblem(new Dictionary<string, string[]> { ["errorCode"] = new string[] { failure.MessageCode.ToString()! } });

        return Problem(failure.MessageCode);
    }

    public static IResult Problem(int? errorCode)
        => Results.Problem(extensions: new Dictionary<string, object?> { [nameof(errorCode)] = errorCode});
}
