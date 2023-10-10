using FluentValidation;
using FluentValidation.Results;

namespace Assinaturas.Application.Core.Behaviours.Validation;

public static class ValidationErrorExtensions
{
    private static FailureItem MapToFailureItem(this ValidationFailure validationFailure)
        => new(validationFailure.PropertyName, validationFailure.ErrorCode, validationFailure.ErrorMessage);

    public static Failure MapToFailure(this ValidationException validationException, string message = default!)
        => new (message ?? validationException.Message, validationException.Errors.Select(MapToFailureItem).ToList());

    public static Failure MapToFailure(this ValidationException validationException, int messageCode)
        => new(messageCode, validationException.Errors.Select(MapToFailureItem).ToList());
}
