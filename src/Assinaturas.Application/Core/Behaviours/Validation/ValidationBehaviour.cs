using FluentValidation;
using MediatR;

namespace Assinaturas.Application.Core.Behaviours.Validation;

internal sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(vld => vld.ValidateAsync(context, cancellationToken)));
            var validationFailures = validationResults?
                .SelectMany(r => r.Errors)?
                .Where(f => f is not null)?
                .ToList();

            if (validationFailures?.Any() ?? false)
                throw new ValidationException(validationFailures);
        }

        return await next();
    }
}
